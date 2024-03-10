using BookLibrary.Models;
using BookLibrary.Models.Enums;
using BookLibrary.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Repositories;

public class BookRepository : IBookRepository
{
    private readonly LibraryDbContext _dbContext;

    public BookRepository(LibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IList<Book>> SearchBooks(SearchBy searchBy, string searchValue)
    {
        var result = await _dbContext.Books
            .AsNoTracking()
            .Where(b => (searchBy == SearchBy.Title && b.Title.StartsWith(searchValue))
                        || (searchBy == SearchBy.Author &&
                            (b.FirstName.StartsWith(searchValue) || b.LastName.StartsWith(searchValue)))
                        || (searchBy == SearchBy.Isbn && b.Isbn!.StartsWith(searchValue)))
            .ToListAsync();

        return result;
    }
}