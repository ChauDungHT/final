using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace final.Models
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(255)]
        public string Password { get; set; }
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }
        public string Images { get; set; } = "default_avt.jpg";
        [Required]
        [MaxLength(20)]
        [EnumDataType(typeof(UserRole))]
        public string Role { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
    }

    public enum UserRole
    {
        Admin,
        Student
    }
}