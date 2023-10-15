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
    public class LettersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public LettersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Letters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Letter>>> GetLetters()
        {
            if (_context.Letters == null)
            {
                return NotFound();
            }


            return await _context.Letters.ToListAsync();
        }
    }
}
