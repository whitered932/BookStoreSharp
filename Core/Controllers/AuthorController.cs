using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contract.Dto;
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

        // GET: api/Author
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            return await _context.Authors.ToListAsync();
        }

        // GET: api/Author/5
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Author>> GetAuthor(Guid id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            return author;
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PatchAuthor(Guid id, UpdateAuthorDto updateAuthorDto)
        {
            var actionResult = await GetAuthor(id);
            var author = actionResult.Value;

            if (updateAuthorDto.Name != null)
                author.Name = updateAuthorDto.Name;
            if (updateAuthorDto.BirthDate != null)
                author.BirthDate = (DateTime) updateAuthorDto.BirthDate;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Author
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(CreateAuthorDto createAuthorDto)
        {
            var author = new Author() {Name = createAuthorDto.Name, BirthDate = createAuthorDto.BirthDate};
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAuthor", new {id = author.Id}, author);
        }

        // DELETE: api/Author/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            var actionResult = await GetAuthor(id);
            var author = actionResult.Value;

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}