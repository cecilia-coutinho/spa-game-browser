using Microsoft.AspNetCore.Authorization;
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
    }
}
