using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SPAGameBrowser.Models
{
    public class UserScoreBoard
    {
        public int UserScoreBoardId { get; set; }
        public int FkUserId { get; set; }
        public string? FkWord { get; set; }
        public int IpAddress { get; set; }
        public int TimeGuesses { get; set; }
        public bool IsGuessesDone { get; set; }
        public DateTime? Started_At { get; set; }
        public DateTime? Finished_At { get; set; }
    }
}
