using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SPAGameBrowser.Models
{
    public class UserScoreBoard
    {
        [Key]
        public int UserScoreBoardId { get; set; }

        [Required, NotNull]
        public int FkUserId { get; set; }

        [Required, NotNull]
        public string? FkWordId { get; set; }

        [Required, NotNull]
        [Display(Name = "IP Address")]
        public int IpAddress { get; set; }

        [Required, NotNull]
        [Display(Name = "Time Guesses")]
        public int TimeGuesses { get; set; } = 0;

        [Required, NotNull]
        public bool IsGuessesDone { get; set; } = false;

        [Required, NotNull]
        public DateTime? Started_At { get; set; }

        [Required]
        public DateTime? Finished_At { get; set; }

    }
}
