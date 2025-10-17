using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sprint4.CSharp.WebApi.Data;
using Sprint4.CSharp.WebApi.DTOs;
using Sprint4.CSharp.WebApi.Models;

namespace Sprint4.CSharp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public ProductsController(AppDbContext db) => _db = db;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetAll()
        {
            var list = await _db.Products.Include(p=>p.Category)
                .Select(p => new ProductReadDto(p.Id,p.Name,p.Price,p.Category!.Name))
                .ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductReadDto>> GetById(int id)
        {
            var p = await _db.Products.Include(x=>x.Category).FirstOrDefaultAsync(x=>x.Id==id);
            if (p is null) return NotFound();
            return new ProductReadDto(p.Id,p.Name,p.Price,p.Category!.Name);
        }

        [HttpPost]
        public async Task<ActionResult<ProductReadDto>> Create(ProductCreateDto dto)
        {
            var cat = await _db.Categories.FindAsync(dto.CategoryId);
            if (cat is null) return BadRequest("Categoria inválida.");
            var p = new Product { Name=dto.Name, Price=dto.Price, Category=cat };
            _db.Products.Add(p);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = p.Id },
                new ProductReadDto(p.Id,p.Name,p.Price,cat.Name));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, ProductCreateDto dto)
        {
            var p = await _db.Products.FindAsync(id);
            if (p is null) return NotFound();
            p.Name = dto.Name; p.Price = dto.Price; p.CategoryId = dto.CategoryId;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var p = await _db.Products.FindAsync(id);
            if (p is null) return NotFound();
            _db.Products.Remove(p);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
