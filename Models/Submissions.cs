using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace final.Models
{
    public enum SubmissionStatus
    {
        Pending,
        Approved,
        Rejected,
        UnderReview
    }

    public class Submissions
    {
        [Key]
        public int SubmissionID { get; set; }
        public int AssignmentID { get; set; }
        public int StudentID { get; set; }
        public int? ReviewedBy { get; set; }
        [Required]
        [MaxLength(255)]
        public string FileName { get; set; }
        [Required]
        [MaxLength(500)]
        public string FilePath { get; set; }
        public long? FileSize { get; set; }
        public DateTime SubmissionDate { get; set; } = DateTime.Now;
        public decimal? PlagiarismScore { get; set; }
        [Required]
        public SubmissionStatus Status { get; set; } = SubmissionStatus.Pending;
        public DateTime? ReviewDate { get; set; }
        public string? Comments { get; set; }
        public bool IsActive { get; set; } = true;
        [ForeignKey("AssignmentID")]
        public virtual Assignments Assignment { get; set; }
        [ForeignKey("StudentID")]
        public virtual Users Student { get; set; }
        [ForeignKey("ReviewedBy")]
        public virtual Users? Reviewer { get; set; }
    }
}
