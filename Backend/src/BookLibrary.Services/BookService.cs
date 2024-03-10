using BookLibrary.Models;
using BookLibrary.Models.Enums;
using BookLibrary.Repositories;

namespace BookLibrary.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    
    public async Task<IList<Book>> SearchBooks(SearchBy searchBy, string searchValue)
    {
        return await _bookRepository.SearchBooks(searchBy, searchValue);
    }
}