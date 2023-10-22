
<h1 align="center">SPA Wordle Game 🧩🧩🎮 </h1>

<p align = center>
by <a href="https://github.com/Cecilia-Coutinho">Cecilia Coutinho</a>
</p>

## 🌍 Overview

The development of this project was required by Chas Academy, and as such, it followed the specified requirements and deadline. 

The application is a web-based word-guessing game featuring user authentication, gameplay, user profiles, and highscores. It operates as a Single Page Application (SPA) with server-side game logic computation. React.js is used for the frontend, while the backend is built using an ASP.NET Core API with controllers.

## 🚀 Features

✅ User authentication with Identity.

✅ Intuitive navigation.

✅ Interactive gameplay.

✅ Highscores tracking.

✅ Single Page Application (SPA) design.

✅ Game logic on the server.

✅ User-friendly interface built with React.js.

✅ ASP.NET Core API backend.


## 💻 Technology Stack

* ASP.NET Core

* C#

* SQL Server Management Studio (SSMS)

* Entity Framework

* React.js 

* HTML

* CSS

* JavaScript

* Visual Studio

* GitHub


## 📋 Additional Information

### SQL Design

The SQL design follows a relational database model, with tables representing entities such as Users, Words, and UserScores to manage user authentication, word selection, and game statistics. Relationships are established using foreign keys to maintain data integrity.

![ER Model](/SPAGameBrowser/wwwroot/images/ER-SPA-Wordle-Game.jpg)


### Code Structure

This project is set up to work as a Single Page Application (SPA) using ASP.NET Core on the server side and React on the client side. The server side handles tasks like managing user accounts and handling requests from the client. The client side is responsible for creating the interactive and dynamic user interface. The structure keeps the code organized and makes it easier to work on different parts of the project.


![Code Structure](SPAGameBrowser/wwwroot/images/code-structure.PNG)


### Server-Side Logic

The server-side logic is organized into three main controllers: Letters, UserScore, and Words. 

The Letters controller manages letter retrieval for the keypad displayed in the game and utilizes caching to improve performance. 

On the client side, it's responsible for the functionality of the colors displayed in the game keypad.

![Keypad Colors](SPAGameBrowser/wwwroot/images/keypad-colors.PNG)


The UserScore controller handles user game statistics, including total games played, games won, winning percentage, and average guesses per game. 

```
    var result = new ScoreViewModel
    {
        Name = user?.Nickname,
        TotalGamesPlayed = totalGamesPlayed,
        TotalGamesWon = totalGamesWon,
        WinningPercentage = winningPercentage,
        AverageGuessesPerGame = averageGuessesPerGame
    };
```

Additionally, it provides endpoints for user statistics, daily highscores, and historical highscores for the leaderboard. 

The Words controller is responsible for retrieving words for the game and with also the usage of caching to enhance performance.

The decision of implementing caching in both the Letters and Words controllers was made to reduce database resquest queries.


```
public async Task<ActionResult<IEnumerable<Word>>> GetWords()
{
    var stopwatch = new Stopwatch();
    stopwatch.Start();

    if (_cache.TryGetValue(cacheKey, out IEnumerable<Word> words))
    {
        _logger.Log(LogLevel.Information, "Words found in cache");
    }
    else
    {
        _logger.Log(LogLevel.Information, "Words NOT found in cache. Loading.");

        if (_context.Words == null)
        {
            return NotFound();
        }

        words = await _context.Words.ToListAsync();

        var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromDays(1))
            .SetAbsoluteExpiration(TimeSpan.FromDays(7))
            .SetPriority(CacheItemPriority.Normal);

        _cache.Set(cacheKey, words, cacheEntryOptions);
    }

    stopwatch.Stop();

    _logger.Log(LogLevel.Information, "PassedTime: " + stopwatch.ElapsedMilliseconds);

    return Ok(words);
}
```

I've applied the randon logic in the client-side, but I think it could to enhance data integrity if I had done it from the server side

```
const fetchSolution = async () => { 
    if (getWord && getWord.length > 0) {
        const randomSolution = getWord[Math.floor(Math.random() * getWord.length)];
        const storedSolution = localStorage.getItem('wordleSolution');
        const storedSolutionId = localStorage.getItem('wordleSolutionId');

        if (storedSolution) {
            setSolution(storedSolution);
            setSolutionId(storedSolutionId);
        } else {
            setSolution(randomSolution.wordName);
            setSolutionId(randomSolution.wordId);
            localStorage.setItem('wordleSolution', randomSolution.wordName);
            localStorage.setItem('wordleSolutionId', randomSolution.wordId);

            const startedAt = (new Date()).toISOString().slice(0, 19).replace(/-/g, "/").replace("T", " ");
            localStorage.setItem('startedAt', startedAt)
        }
    }
```

I've used local.storage for user's state persistance in the game so if the players comes back to the page the game will look like the last time they played, with the exception of browser's cache cleaning.

#### Seed Data



### Conclusion



