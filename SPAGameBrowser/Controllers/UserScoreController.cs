using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPAGameBrowser.Data;
using SPAGameBrowser.Models;

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

        // GET: api/UsersScore
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserScore>>> GetAllUsersScores()
        {
            if (_context.UserScores == null)
            {
                return NotFound();
            }
            return await _context.UserScores.ToListAsync();
        }

        // GET: api/UserScore/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<UserScore>>> GetUserScores(string id)
        {
            if (_context.UserScores == null)
            {
                return NotFound();
            }
            var userScoreBoard = await _context.UserScores
                .Where(us => us.FkUserId == id)
                .OrderByDescending(us => us.Finished_At)
                .ToListAsync();

            if (userScoreBoard == null)
            {
                return NotFound();
            }

            return userScoreBoard;
        }

        // POST: api/UserScoreBoards
        [HttpPost]
        public async Task<ActionResult<UserScore>> PostUserScore(UserScore userScore)
        {
            if (_context.UserScores == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserScores'  is null.");
            }

            _context.UserScores.Add(userScore);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserScoreBoard", new { id = userScore.UserScoreId }, userScore);
        }
    }
}
