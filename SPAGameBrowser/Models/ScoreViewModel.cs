using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SPAGameBrowser.Models
{
    public class ScoreViewModel
    {
        public int UserScoreId { get; set; }
        public string? FkUserId { get; set; }
        public int? FkWordId { get; set; }
        public int Attempts { get; set; }
        public bool IsGuessed { get; set; }
        public string? Started_At { get; set; }
        public string? Finished_At { get; set; }

    }
}
