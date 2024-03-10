using BookLibrary.Models.Enums;
using BookLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BookLibrary.Api.EndpointsDefinition;

public class ApiEndpoints
{
    private const string SearchBooks = "/books";
    
    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet(SearchBooks, SearchBooksEndpoint);
    }

    [SwaggerResponse(StatusCodes.Status200OK, "Ok")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Bad request")]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Not found")]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Server error")]
    private async Task<IResult> SearchBooksEndpoint(
        [FromQuery] SearchBy searchBy,
        [FromQuery] string searchValue,
        [FromServices] IBookService bookService)
    {
        var books = await bookService.SearchBooks(searchBy, searchValue);
        
        return books switch
        {
            null => Results.NotFound(),
            { Count: 0 } => Results.NotFound(),
            _ => Results.Ok(books)
        };
    }
}