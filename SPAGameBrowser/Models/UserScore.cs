using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SPAGameBrowser.Models
{
    public class UserScore
    {
        [Key]
        public int UserScoreId { get; set; }

        public string? FkUserId { get; set; }

        [Required, NotNull]
        public int? FkWordId { get; set; }

        [Required, NotNull]
        [Display(Name = "Attempts")]
        [Range(0, 6)]
        public int Attempts { get; set; }

        [Required, NotNull]
        public bool IsGuessed { get; set; }

        [Required, NotNull]
        public string? Started_At { get; set; }

        [Required]
        public string? Finished_At { get; set; }


        [ForeignKey("FkUserId")]
        public virtual ApplicationUser? ApplicationUsers { get; set; }

        [ForeignKey("FkWordId")]
        public virtual Word? Words { get; set; }

    }
}
