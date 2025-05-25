using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace final.Models
{
    public class Assignments
    {
        [Key]
        public int AssignmentID { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;

        // Navigation properties
        [ForeignKey("CategoryID")]
        public virtual Categories Category { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual Users Creator { get; set; }
    }
}
