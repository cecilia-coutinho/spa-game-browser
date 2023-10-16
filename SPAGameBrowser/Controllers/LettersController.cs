using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SPAGameBrowser.Data;
using SPAGameBrowser.Models;
using System.Diagnostics;

namespace SPAGameBrowser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LettersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string cacheKey = "lettersCacheKey";
        private readonly ILogger<LettersController> _logger;
        public LettersController(ApplicationDbContext context, IMemoryCache cache, ILogger<LettersController> logger)
        {
            _context = context;
            _cache = cache;
            _logger = logger;
        }

        // GET: api/Letters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Letter>>> GetLetters()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            if (_cache.TryGetValue(cacheKey, out IEnumerable<Letter> letters))
            {
                _logger.Log(LogLevel.Information, "Letters found in cache");
            }
            else
            {
                _logger.Log(LogLevel.Information, "Letters NOT found in cache. Loading.");

                if (_context.Letters == null)
                {
                    return NotFound();
                }

                letters = await _context.Letters.ToListAsync();

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromDays(365))
                    .SetPriority(CacheItemPriority.NeverRemove);

                _cache.Set(cacheKey, letters, cacheEntryOptions);
            }

            stopwatch.Stop();

            _logger.Log(LogLevel.Information, "PassedTime: " + stopwatch.ElapsedMilliseconds);

            return Ok(letters);
        }
    }
}
