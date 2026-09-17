using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Redcode.Data;
using Redcode.Models;
using System.Security.Claims;

namespace Redcode.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class QuotesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public QuotesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quote>>> GetQuotes()
        {
            var userId = int.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)!
            );

            return await _context.Quotes
                .Where(quote => quote.UserId == userId)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Quote>> CreateQuote(Quote quote)
        {
            var userId = int.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)!
            );

            quote.UserId = userId;

            _context.Quotes.Add(quote);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetQuotes), new { id = quote.ID }, quote);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuote(int id, Quote quote)
        {
            var userId = int.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)!
            );

            var existingQuote = await _context.Quotes
                .FirstOrDefaultAsync(q => q.ID == id && q.UserId == userId);

            if (existingQuote == null)
            {
                return NotFound();
            }

            existingQuote.Text = quote.Text;
            existingQuote.Källa = quote.Källa;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuote(int id)
        {
            var userId = int.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)!
            );

            var quote = await _context.Quotes
                .FirstOrDefaultAsync(q => q.ID == id && q.UserId == userId);

            if (quote == null)
            {
                return NotFound();
            }

            _context.Quotes.Remove(quote);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}