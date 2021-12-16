using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contract.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Contract.Models;
using Data;

namespace Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly BookContext _context;

        public AuthorController(BookContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            return await _context.Authors.ToListAsync();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Author>> GetAuthor(Guid id)
        {
            var author = await _context.Authors
                .Include(a => a.Books)
                .FirstAsync(a => a.Id == id);

            if (author == null)
            {
                return NotFound();
            }

            return author;
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> PutAuthor(Guid id, UpdateAuthorDto updateAuthorDto)
        {
            var getAuthorResult = await GetAuthor(id);
            var author = getAuthorResult.Value;

            author.Name = updateAuthorDto.Name;
            author.BirthDate = updateAuthorDto.BirthDate;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(CreateAuthorDto createAuthorDto)
        {
            var author = new Author() {Name = createAuthorDto.Name, BirthDate = createAuthorDto.BirthDate};
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthor", new {id = author.Id}, author);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            var getAuthorResult = await GetAuthor(id);
            var author = getAuthorResult.Value;

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}