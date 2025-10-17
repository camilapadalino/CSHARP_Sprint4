using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sprint4.CSharp.WebApi.Data;

namespace Sprint4.CSharp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LinqController : ControllerBase
    {
        private readonly AppDbContext _db;
        public LinqController(AppDbContext db) => _db = db;

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string term)
        {
            term = term?.ToLower() ?? "";
            var result = await _db.Products
                .Where(p => p.Name.ToLower().Contains(term))
                .OrderBy(p => p.Name)
                .Select(p => new { p.Id, p.Name, p.Price })
                .ToListAsync();
            return Ok(result);
        }

        [HttpGet("top-expensive")]
        public async Task<IActionResult> TopExpensive([FromQuery] int take = 3)
        {
            var result = await _db.Products
                .OrderByDescending(p => p.Price)
                .Take(take)
                .Select(p => new { p.Id, p.Name, p.Price })
                .ToListAsync();
            return Ok(result);
        }

        [HttpGet("paged")]
        public async Task<IActionResult> Paged([FromQuery] int page = 1, [FromQuery] int pageSize = 2)
        {
            var skip = (page - 1) * pageSize;
            var total = await _db.Products.CountAsync();
            var items = await _db.Products
                .OrderBy(p => p.Id)
                .Skip(skip)
                .Take(pageSize)
                .Select(p => new { p.Id, p.Name, p.Price })
                .ToListAsync();
            return Ok(new { page, pageSize, total, items });
        }
    }
}
