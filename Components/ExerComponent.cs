using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final.Models;
using Microsoft.AspNetCore.Mvc;

namespace final.Components
{
    [ViewComponent(Name = "ExerView")]
    public class ExerComponent : ViewComponent
    {
        private readonly DataContext _context;
        public ExerComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var elist = (from m in _context.Exers
                            where (m.IsActive == true)
                            select m).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", elist));
        }
    }
}