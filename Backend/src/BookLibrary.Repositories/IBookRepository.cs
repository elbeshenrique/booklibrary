using BookLibrary.Models;
using BookLibrary.Models.Enums;

namespace BookLibrary.Repositories;

public interface IBookRepository
{
    Task<IList<Book>> SearchBooks(SearchBy searchBy, string searchValue);
}