using Administradora_de_libros.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Identity.Client;

namespace Administradora_de_libros.Controllers
{
    
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> SearchBooks([FromQuery] string? title, [FromQuery] string? author)
        {
            var query = _context.Books.AsQueryable();

            if (!string.IsNullOrWhiteSpace(title))
            {
                query = query.Where(b => b.Title.Contains(title));
            }

            if (!string.IsNullOrWhiteSpace(author))
            {
                query = query.Where(b => b.Author.Contains(author));
            }

            var books = await query.ToListAsync();

            return Ok(books);
        }


        [HttpPost("MoreThanOne")]
        public async Task<ActionResult<IEnumerable<Book>>> Post(Book[] books)
        {
            _context.AddRange(books);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> AddBooks(Book book)
        {
            _context.Add(book);

            await _context.SaveChangesAsync();
            
            return Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Book updatedBook)
        {
            var existingBook = await _context.Books.FindAsync(id);
            if (existingBook == null)
            {
                return NotFound();
            }

            existingBook.Title = updatedBook.Title ?? existingBook.Title;
            existingBook.Description = updatedBook.Description ?? existingBook.Description;
            existingBook.Author = updatedBook.Author ?? existingBook.Author;
            existingBook.ISBN = updatedBook.ISBN ?? existingBook.ISBN;

            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null) return NotFound();

            _context.Remove(book);

            await _context.SaveChangesAsync();

            return Ok(book);
        }

    }
}
