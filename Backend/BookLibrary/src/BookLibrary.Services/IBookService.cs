using BookLibrary.Models;
using BookLibrary.Models.Enums;

namespace BookLibrary.Services;

public interface IBookService
{
    Task<IList<Book>> SearchBooks(SearchBy searchBy, string searchValue);
}