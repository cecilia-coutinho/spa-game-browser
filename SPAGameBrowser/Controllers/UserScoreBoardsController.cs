using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPAGameBrowser.Data;
using SPAGameBrowser.Models;

namespace SPAGameBrowser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserScoreBoardsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserScoreBoardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UserScoreBoards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserScore>>> GetAllUsersScores()
        {
          if (_context.UserScores == null)
          {
              return NotFound();
          }
            return await _context.UserScores.ToListAsync();
        }

        // GET: api/UserScoreBoards/5
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
        public async Task<ActionResult<UserScore>> PostUserScoreBoard(UserScore userScoreBoard)
        {
          if (_context.UserScores == null)
          {
              return Problem("Entity set 'ApplicationDbContext.UserScores'  is null.");
          }

            _context.UserScores.Add(userScoreBoard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserScoreBoard", new { id = userScoreBoard.UserScoreId }, userScoreBoard);
        }
    }
}
