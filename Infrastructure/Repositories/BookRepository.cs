using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BookRepository : BaseRepository<Book> , IBookRepository
{
    public BookRepository(ApplicationDbContext context) : base(context) {}
    
    public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(string author) => await _context.Books.Where(x => x.Author == author).ToListAsync();
    
}