using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace final.Models
{
    public class PlagiarismResults
    {
        [Key]
        public int ResultID { get; set; }
        public int SubmissionID { get; set; }
        public string OriginalText { get; set; }
        public string PlagiarizedText { get; set; }
        [MaxLength(500)]
        public string? SourceURL { get; set; }
        public decimal? SimilarityScore { get; set; }
        public int? StartPosition { get; set; }
        public int? EndPosition { get; set; }
        public DateTime CheckDate { get; set; } = DateTime.Now;
        [ForeignKey("SubmissionID")]
        public virtual Submissions Submission { get; set; }
    }
}
