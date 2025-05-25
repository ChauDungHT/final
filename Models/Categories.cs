using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace final.Models
{
    public class Categories
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Foreign key
        public int? CreatedBy { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual Users? CreatedByUser { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
