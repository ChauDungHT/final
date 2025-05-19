using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using final.Models;
using final.Utilities;

namespace final.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DataContext _context;

    public HomeController(ILogger<HomeController> logger, DataContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        if (!Functions.IsLogin())
        {
            return RedirectToAction("Index", "Login", new { area = "Admin" });
        }
        return View();
    }

    public IActionResult Logout()
    {
        Functions._UserId = 0;
        Functions._UserName = string.Empty;
        Functions._Email = string.Empty;
        Functions._Message = string.Empty;
        return RedirectToAction("Index", "Home", new { area = "Admin" });
    }

    [Route("/exer-{slug}-{id:int}.html", Name = "Details")]
    public IActionResult Details(int? id)
    {
        if (id == null)
            return NotFound();
        var exer = _context.Exers.FirstOrDefault(e => (e.ExerId == id));
        if (exer == null)
            return NotFound();
        return View(exer);    
    }

    [HttpGet]
    public IActionResult Upload(int exerId)
    {
        return View(exerId); 
    }

    [HttpPost]
    public async Task<IActionResult> Upload(int exerId, IFormFile pdfFile)
    {
        if (pdfFile != null && pdfFile.Length > 0)
        {
            var fileExt = Path.GetExtension(pdfFile.FileName).ToLower();
            if (fileExt != ".pdf")
            {
                TempData["UploadSuccess"] = "Chỉ chấp nhận file PDF.";
                return RedirectToAction("Details", new { id = exerId });
            }

            var fileName = $"exer_{exerId}_{DateTime.Now:yyyyMMddHHmmss}.pdf";
            var relativePath = $"/uploads/{fileName}";
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await pdfFile.CopyToAsync(stream);
            }

            // 👉 Lưu vào database
            var eu = new tblEU
            {
                UID = 1, // Tạm thời hardcode, sau này lấy từ session / user login
                EID = exerId,
                FilePath = relativePath,
                IsAcepted = false,
                SubmitDate = DateTime.Now
            };

            _context.EUs.Add(eu);
            await _context.SaveChangesAsync();

            TempData["UploadSuccess"] = "Nộp bài thành công!";
            return Redirect("/#services");
        }

        TempData["UploadSuccess"] = "Chưa chọn file hoặc file không hợp lệ!";
        return RedirectToAction("Details", new { id = exerId });
    }



    
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
