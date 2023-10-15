using Microsoft.EntityFrameworkCore;

namespace SPAGameBrowser.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed (this ModelBuilder modelBuilder)
        {
            //Words:
            modelBuilder.Entity<Word>().HasData(new[]
            {
                new Word { WordId = 1, WordName = "apple" },
                new Word { WordId = 2, WordName = "chair" },
                new Word { WordId = 3, WordName = "house" },
                new Word { WordId = 4, WordName = "table" },
                new Word { WordId = 5, WordName = "knife" },
                new Word { WordId = 6, WordName = "books" },
                new Word { WordId = 7, WordName = "paper" },
                new Word { WordId = 8, WordName = "music" },
                new Word { WordId = 9, WordName = "globe" },
                new Word { WordId = 10, WordName = "stars" },
                new Word { WordId = 11, WordName = "radio" },
                new Word { WordId = 12, WordName = "queen" },
                new Word { WordId = 13, WordName = "clock" },
                new Word { WordId = 14, WordName = "watch" },
                new Word { WordId = 15, WordName = "glass" },
                new Word { WordId = 16, WordName = "water" },
                new Word { WordId = 17, WordName = "plant" },
                new Word { WordId = 18, WordName = "earth" },
                new Word { WordId = 19, WordName = "grape" },
                new Word { WordId = 20, WordName = "beach" },
                new Word { WordId = 21, WordName = "candy" },
                new Word { WordId = 22, WordName = "frost" },
                new Word { WordId = 23, WordName = "crown" },
                new Word { WordId = 24, WordName = "lions" },
                new Word { WordId = 25, WordName = "heart" },
                new Word { WordId = 26, WordName = "bells" },
                new Word { WordId = 27, WordName = "peace" },
                new Word { WordId = 28, WordName = "pride" },
                new Word { WordId = 29, WordName = "raven" },
                new Word { WordId = 30, WordName = "torch" },
                new Word { WordId = 31, WordName = "smile" },
                new Word { WordId = 32, WordName = "sushi" },
                new Word { WordId = 33, WordName = "swiss" },
                new Word { WordId = 34, WordName = "darts" },
                new Word { WordId = 35, WordName = "horse" },
                new Word { WordId = 36, WordName = "lamps" },
                new Word { WordId = 37, WordName = "birds" },
                new Word { WordId = 38, WordName = "magic" },
                new Word { WordId = 39, WordName = "ocean" },
                new Word { WordId = 40, WordName = "route" },
                new Word { WordId = 41, WordName = "trout" },
                new Word { WordId = 42, WordName = "flame" },
                new Word { WordId = 43, WordName = "sugar" },
                new Word { WordId = 44, WordName = "couch" },
                new Word { WordId = 45, WordName = "spear" },
                new Word { WordId = 46, WordName = "chess" },
                new Word { WordId = 47, WordName = "piano" },
                new Word { WordId = 48, WordName = "cigar" },
                new Word { WordId = 49, WordName = "hills" },
                new Word { WordId = 50, WordName = "fairy" },
                new Word { WordId = 51, WordName = "wings" },
                new Word { WordId = 52, WordName = "beard" },
                new Word { WordId = 53, WordName = "flute" },
                new Word { WordId = 54, WordName = "space" },
                new Word { WordId = 55, WordName = "tiger" },
                new Word { WordId = 56, WordName = "zebra" },
                new Word { WordId = 57, WordName = "dolph" },
                new Word { WordId = 58, WordName = "angel" },
                new Word { WordId = 59, WordName = "panda" },
                new Word { WordId = 60, WordName = "juice" },
                new Word { WordId = 61, WordName = "honey" },
                new Word { WordId = 62, WordName = "dream" },
                new Word { WordId = 63, WordName = "happy" }
            });

            //Letters:
            modelBuilder.Entity<Letter>().HasData(new[]
            {
                new Letter { LetterId = 1, Key = 'a' },
                new Letter { LetterId = 2, Key = 'b' },
                new Letter { LetterId = 3, Key = 'c' },
                new Letter { LetterId = 4, Key = 'd' },
                new Letter { LetterId = 5, Key = 'e' },
                new Letter { LetterId = 6, Key = 'f' },
                new Letter { LetterId = 7, Key = 'g' },
                new Letter { LetterId = 8, Key = 'h' },
                new Letter { LetterId = 9, Key = 'i' },
                new Letter { LetterId = 10, Key = 'j' },
                new Letter { LetterId = 11, Key = 'k' },
                new Letter { LetterId = 12, Key = 'l' },
                new Letter { LetterId = 13, Key = 'm' },
                new Letter { LetterId = 14, Key = 'n' },
                new Letter { LetterId = 15, Key = 'o' },
                new Letter { LetterId = 16, Key = 'p' },
                new Letter { LetterId = 17, Key = 'q' },
                new Letter { LetterId = 18, Key = 'r' },
                new Letter { LetterId = 19, Key = 's' },
                new Letter { LetterId = 20, Key = 't' },
                new Letter { LetterId = 21, Key = 'u' },
                new Letter { LetterId = 22, Key = 'v' },
                new Letter { LetterId = 23, Key = 'w' },
                new Letter { LetterId = 24, Key = 'x' },
                new Letter { LetterId = 25, Key = 'y' },
                new Letter { LetterId = 26, Key = 'z' }
            });
        }
    }
}
