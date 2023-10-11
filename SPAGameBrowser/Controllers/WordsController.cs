using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPAGameBrowser.Data;
using SPAGameBrowser.Models;

namespace SPAGameBrowser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WordsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public WordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Words
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Word>>> GetWords()
        {
          if (_context.Words == null)
          {
              return NotFound();
          }
            return await _context.Words.ToListAsync();
        }

        // GET: api/Words/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Word>> GetWord(int id)
        {
          if (_context.Words == null)
          {
              return NotFound();
          }
            var word = await _context.Words.FindAsync(id);

            if (word == null)
            {
                return NotFound();
            }

            return word;
        }

        // GET: api/Word?userId={userId}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<char>>> GetWord([FromQuery] string userId)
        {
            char[] characters = Array.Empty<char>();

            if (_context.UserScores == null)
            {
                if (_context.Words == null)
                {
                    return NotFound("No word found in the context");
                }

                var word = await _context.Words
                    .OrderBy(w => w.WordId)
                    .FirstOrDefaultAsync();

                if (word == null)
                {
                    return NotFound("No word found!");
                }

                characters = word.WordName.ToCharArray();
            }
            else
            {
                UserScoreBoard? userScore = await _context.UserScores
                .Where(us => us.FkUserId == userId && us.Finished_At == null)
                .OrderByDescending(us => us.Started_At)
                .FirstOrDefaultAsync();
                
                if (userScore != null)
                {
                    int fkWordId = userScore.FkWordId.GetValueOrDefault();

                    if (_context.Words == null)
                    {
                        return NotFound("No word found in the context");
                    }

                    Word? word = await _context.Words
                        .FindAsync(fkWordId);

                    if (word != null)
                    {
                        characters = word.WordName.ToCharArray();
                    }
                }
                else
                {
                    if (_context.Words == null)
                    {
                        return NotFound("No word found in the context");
                    }

                    var word = await _context.Words
                        .OrderBy(w => w.WordId)
                        .FirstOrDefaultAsync();

                    if (word == null)
                    {
                        return NotFound("No word found!");
                    }

                    characters = word.WordName.ToCharArray();
                }
            }
            return Ok(characters);
        }

        //// PUT: api/Words/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutWord(int id, Word word)
        //{
        //    if (id != word.WordId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(word).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!WordExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Words
        //[HttpPost]
        //public async Task<ActionResult<Word>> PostWord(Word word)
        //{
        //  if (_context.Words == null)
        //  {
        //      return Problem("Entity set 'ApplicationDbContext.Words'  is null.");
        //  }
        //    _context.Words.Add(word);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetWord", new { id = word.WordId }, word);
        //}

        //// DELETE: api/Words/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteWord(int id)
        //{
        //    if (_context.Words == null)
        //    {
        //        return NotFound();
        //    }
        //    var word = await _context.Words.FindAsync(id);
        //    if (word == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Words.Remove(word);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool WordExists(int id)
        {
            return (_context.Words?.Any(e => e.WordId == id)).GetValueOrDefault();
        }
    }
}
