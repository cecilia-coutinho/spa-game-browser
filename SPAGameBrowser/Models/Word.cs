using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace SPAGameBrowser.Models
{
    public class Word
    {
        [Key]
        public int WordId { get; set; }

        [Required, NotNull]
        [Display (Name = "Word")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "5-letter words only.")]
        public string? WordName { get; set; }

        public UserScoreBoard? Scoreboard { get; set; }
    }
}
