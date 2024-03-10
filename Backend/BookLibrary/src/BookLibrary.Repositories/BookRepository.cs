using BookLibrary.Models;
using BookLibrary.Models.Enums;

namespace BookLibrary.Repositories;

public class BookRepository : IBookRepository
{
    public async Task<IList<Book>> SearchBooks(SearchBy searchBy, string searchValue)
    {
        await Task.CompletedTask;
        return Enumerable.Empty<Book>().ToList();
    }
}