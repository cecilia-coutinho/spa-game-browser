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
        public async Task<ActionResult<IEnumerable<UserScoreBoard>>> GetUserScores()
        {
          if (_context.UserScores == null)
          {
              return NotFound();
          }
            return await _context.UserScores.ToListAsync();
        }

        // GET: api/UserScoreBoards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserScoreBoard>> GetUserScoreBoard(int id)
        {
          if (_context.UserScores == null)
          {
              return NotFound();
          }
            var userScoreBoard = await _context.UserScores.FindAsync(id);

            if (userScoreBoard == null)
            {
                return NotFound();
            }

            return userScoreBoard;
        }

        // PUT: api/UserScoreBoards/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserScoreBoard(int id, UserScoreBoard userScoreBoard)
        {
            if (id != userScoreBoard.UserScoreId)
            {
                return BadRequest();
            }

            _context.Entry(userScoreBoard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserScoreBoardExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserScoreBoards
        [HttpPost]
        public async Task<ActionResult<UserScoreBoard>> PostUserScoreBoard(UserScoreBoard userScoreBoard)
        {
          if (_context.UserScores == null)
          {
              return Problem("Entity set 'ApplicationDbContext.UserScores'  is null.");
          }
            _context.UserScores.Add(userScoreBoard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserScoreBoard", new { id = userScoreBoard.UserScoreId }, userScoreBoard);
        }

        // DELETE: api/UserScoreBoards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserScoreBoard(int id)
        {
            if (_context.UserScores == null)
            {
                return NotFound();
            }
            var userScoreBoard = await _context.UserScores.FindAsync(id);
            if (userScoreBoard == null)
            {
                return NotFound();
            }

            _context.UserScores.Remove(userScoreBoard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserScoreBoardExists(int id)
        {
            return (_context.UserScores?.Any(e => e.UserScoreId == id)).GetValueOrDefault();
        }
    }
}
