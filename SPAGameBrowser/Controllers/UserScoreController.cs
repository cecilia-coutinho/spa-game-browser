using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPAGameBrowser.Data;
using SPAGameBrowser.Models;
using System.Security.Claims;

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
        public async Task<ActionResult<IEnumerable<UserScore>>> GetUserScores()
        {
            if (_context.UserScores == null || _context.Users == null)
            {
                return Problem("Entity is null.");
            }

            var result = await _context.UserScores
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

                    AverageGuessesPerGame = group.Average(h => h.UserScore.Attempts)
                })
                .ToListAsync();

            return Ok(result);
        }

        //// GET: api/UserScore/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<IEnumerable<UserScore>>> GetUserScores(string id)
        //{
        //    if (_context.UserScores == null)
        //    {
        //        return NotFound();
        //    }
        //    var userScoreBoard = await _context.UserScores
        //        .Where(us => us.FkUserId == id)
        //        .OrderByDescending(us => us.Finished_At)
        //        .ToListAsync();

        //    if (userScoreBoard == null)
        //    {
        //        return NotFound();
        //    }

        //    return userScoreBoard;
        //}

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
        //public async Task<IActionResult> GetDailyScores(string userId)
        //{
        //    DateTime today = DateTime.Today;

        //    if (_context.UserScores == null)
        //    {
        //        return NotFound();
        //    }

        //    List<UserScore> dailyScores = await _context.UserScores
        //        .Where(score => DateTime.Parse(score.Started_At).Date == today && score.IsGuessed)
        //        .OrderBy(score => score.Attempts)
        //        .ToListAsync();

        //    var viewModel = new ScoreViewModel
        //    {
        //        DailyScores = dailyScores
        //    };

        //    return Ok(viewModel);
        //}
    }
}
