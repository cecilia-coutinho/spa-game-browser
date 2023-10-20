using Humanizer;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPAGameBrowser.Data;
using SPAGameBrowser.Models;
using System.Globalization;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace SPAGameBrowser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserScoreController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserScoreController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UserScore
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserScore>> GetUserStatistics()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return BadRequest("User ID not found.");
            }

            try
            {
                if (_context.UserScores == null)
                {
                    return Problem("Entity is null.", statusCode: 500);
                }

                var userScores = await _context.UserScores
                    .Where(us => us.FkUserId == userId)
                    .ToListAsync();

                if (userScores == null || userScores.Count == 0)
                {
                    return NotFound("No scores for this user");
                }

                var totalGamesPlayed = userScores.Count;
                var totalGamesWon = userScores.Count(us => us.IsGuessed == true);
                var winningPercentage = Math.Round((double)totalGamesWon / totalGamesPlayed * 100, 2);
                var averageGuessesPerGame = Math.Round(userScores.Average(us => us.Attempts), 2);

                if (_context.Users == null)
                {
                    return Problem("Entity is null.", statusCode: 500);
                }

                var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == userId);

                var result = new ScoreViewModel
                {
                    Name = user?.Nickname,
                    TotalGamesPlayed = totalGamesPlayed,
                    TotalGamesWon = totalGamesWon,
                    WinningPercentage = winningPercentage,
                    AverageGuessesPerGame = averageGuessesPerGame
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        // GET: api/DailyHighscores
        [HttpGet("Daily")]
        public async Task<ActionResult<IEnumerable<UserScore>>> DailyHighscores()
        {
            try
            {
                string today = DateTime.Today.Date.ToString("yyyy/MM/dd");


                if (_context.UserScores == null || _context.Users == null)
                {
                    return Problem("Entity is null.", statusCode: 500);
                }

                var result = await _context.UserScores
                    .Where(score => score.IsGuessed == true)
                    .OrderByDescending(score => score.Attempts)
                    .ThenBy(score => score.Finished_At)
                    .Take(10)
                    .Join(_context.Users,
                        h => h.FkUserId,
                        u => u.Id,
                        (h, u) => new { UserScore = h, User = u }
                    )
                    .GroupBy(joined => joined.User.Nickname)
                    .OrderByDescending(group => group.Count())
                    .Select(group => new ScoreViewModel()
                    {
                        Name = group.Key,
                        TotalGamesWon = group.Count(h =>
                        h.UserScore.IsGuessed == true &&
                        h.UserScore.Finished_At != null &&
                        h.UserScore.Finished_At.Substring(0, 10) == today
                        ),
                    })
                    .ToListAsync();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }

        }

        // GET: api/UserScore
        [HttpGet("History")]
        public async Task<ActionResult<IEnumerable<UserScore>>> GetHistoricalHighscores()
        {
            if (_context.UserScores == null || _context.Users == null)
            {
                return Problem("Entity is null.");
            }

            var result = await _context.UserScores
                .Where(score => score.IsGuessed == true)
                .OrderByDescending(score => score.Attempts)
                .ThenBy(score => score.Finished_At)
                .Take(10)
                .Join(_context.Users,
                    h => h.FkUserId,
                    u => u.Id,
                    (h, u) => new { UserScore = h, User = u }
                )
                .GroupBy(joined => joined.User.Nickname)
                .Select(group => new ScoreViewModel()
                {
                    Name = group.Key,
                    TotalGamesPlayed = group.Count(),

                    TotalGamesWon = group.Count(h => h.UserScore.IsGuessed == true),

                    WinningPercentage = Math.Round((double)group.Count(h => h.UserScore.IsGuessed == true) * 100.0 / group.Count(), 2),

                    AverageGuessesPerGame = Math.Round(group.Average(h => h.UserScore.Attempts), 2)
                })
                .ToListAsync();

            return Ok(result);
        }

        // POST: api/UserScore
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<UserScore>> PostUserScore(UserScore userScore)
        {
            if (_context.UserScores == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserScores'  is null.");
            }

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                throw new ArgumentNullException("userId");
            }

            userScore.FkUserId = userId;
            _context.UserScores.Add(userScore);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserScore", new { id = userScore.UserScoreId }, userScore);
        }
    }
}
