using NovaCode_Web_Services.Dashboard.Domain.Model.Aggregate;
using NovaCode_Web_Services.Dashboard.Domain.Model.Commands;

namespace NovaCode_Web_Services.Dashboard.Domain.Services;

public interface IBookCommandService
{
    Task<Book?> Handle(int id,UpdateBookCommand command);
    Task<bool?> Handle(DeleteBookCommand command);
}