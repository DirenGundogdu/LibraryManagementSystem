using Core.Entities;

namespace Core.Interfaces;

public interface IBookRepository : IRepository<Book>
{
    Task<IEnumerable<Book>> GetBooksByAuthorAsync(string author);
}