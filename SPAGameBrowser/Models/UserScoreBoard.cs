using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SPAGameBrowser.Models
{
    public class UserScoreBoard
    {
        [Key]
        public int UserScoreId { get; set; }

        [Required, NotNull]
        public string? FkUserId { get; set; }

        [Required, NotNull]
        public int? FkWordId { get; set; }

        [Required, NotNull]
        [Display(Name = "IP Address")]
        public int IpAddress { get; set; }

        [Required, NotNull]
        [Display(Name = "Time Guesses")]
        [Range(0, 5)]
        public int TimeGuesses { get; set; } = 0;

        [Required, NotNull]
        public bool IsGuessesDone { get; set; } = false;

        [Required, NotNull]
        public DateTime? Started_At { get; set; }

        [Required]
        public DateTime? Finished_At { get; set; }


        [ForeignKey("FkUserId")]
        public virtual ApplicationUser? ApplicationUsers { get; set; }

        [ForeignKey("FkWordId")]
        public virtual Word? Words { get; set; }

    }
}
