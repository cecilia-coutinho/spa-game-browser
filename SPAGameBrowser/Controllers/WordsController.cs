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
    public class WordsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly string cacheKey = "wordsCacheKey";
        private readonly ILogger<WordsController> _logger;
        public WordsController(ApplicationDbContext context, IMemoryCache cache, ILogger<WordsController> logger)
        {
            _context = context;
            _cache = cache;
            _logger = logger;
        }

        // GET: api/Words
        [HttpGet]
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


        //public IActionResult ClearCache()
        //{
        //    _cache.Remove(cacheKey);
        //    _logger.Log(LogLevel.Information, "Cleared cache");

        //    return Ok();
        //}
    }
}
