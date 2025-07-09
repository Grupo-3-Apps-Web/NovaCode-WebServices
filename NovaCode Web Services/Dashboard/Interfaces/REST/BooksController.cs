using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using NovaCode_Web_Services.Dashboard.Domain.Model.Commands;
using NovaCode_Web_Services.Dashboard.Domain.Model.Queries;
using NovaCode_Web_Services.Dashboard.Domain.Services;
using NovaCode_Web_Services.Dashboard.Interfaces.REST.Resources;
using NovaCode_Web_Services.Dashboard.Interfaces.REST.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace NovaCode_Web_Services.Dashboard.Interfaces.REST;

[ApiController]
[Route("api/v1/myBookedVehicles")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Dashboard vehicles reserved")]
public class BooksController(IBookCommandService bookCommandService, IBookQueryService bookQueryService): ControllerBase
{
    [HttpGet]
    [SwaggerOperation("Get all Dashboard", "Get a list of all book vehicles", OperationId = "GetAllBook")]
    [SwaggerResponse(200, "The list of book vehicles was founs and returned.", typeof(IEnumerable<BookResource>))]
    public async Task<IActionResult> GetAllBook()
    {
        var getAllBookQuery = new GetAllBookQuery();
        var books = await bookQueryService.Handle(getAllBookQuery);

        if (books == null || !books.Any())
        {
            return NotFound("No books found");
        }

        var bookResources = books.Select(BookResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(bookResources);
    }

    [HttpDelete("{id:int}")]
    [SwaggerOperation("Delete Vehicles reserved", "Delete dashboard information", OperationId = "DeleteBook")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        try
        {
            var deleteBookCommand = new DeleteBookCommand(id);
            var bookDeleted = await bookCommandService.Handle(deleteBookCommand);

            if (bookDeleted is null)
                return NotFound($"Book with id {id} was not found");

            return Ok("Book deleted successfully");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
}