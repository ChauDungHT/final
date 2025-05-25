using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace final.Models
{
    public enum InteractionTypeEnum
    {
        Summary,
        QA,
        Analysis
    }

    public class AIInteractions
    {
        [Key]
        public int InteractionID { get; set; }
        public int SubmissionID { get; set; }
        public int UserID { get; set; }
        public string Question { get; set; }
        public string Response { get; set; }
        [Required]
        public InteractionTypeEnum InteractionType { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [ForeignKey("SubmissionID")]
        public virtual Submissions submission { get; set; }
        [ForeignKey("UserID")]
        public virtual Users User { get; set; }
    }
}
