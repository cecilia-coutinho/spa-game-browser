namespace SPAGameBrowser.Models
{
    public class ScoreViewModel
    {
        public string? Name { get; set; }
        public int TotalGamesPlayed { get; set; }
        public int TotalGamesWon { get; set; }
        public double WinningPercentage { get; set; }
        public double AverageGuessesPerGame { get; set; }
    }
}
