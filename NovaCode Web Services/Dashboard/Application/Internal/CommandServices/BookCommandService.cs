using NovaCode_Web_Services.Dashboard.Domain.Model.Aggregate;
using NovaCode_Web_Services.Dashboard.Domain.Model.Commands;
using NovaCode_Web_Services.Dashboard.Domain.Repositories;
using NovaCode_Web_Services.Dashboard.Domain.Services;
using NovaCode_Web_Services.Shared.Domain.Repositories;

namespace NovaCode_Web_Services.Dashboard.Application.Internal.CommandServices;

public class BookCommandService(IBookRepository bookRepository, IUnitOfWork unitOfWork ): IBookCommandService
{
    public async Task<bool?> Handle(DeleteBookCommand command)
    {
        var book = await bookRepository.FindByIdAsync(command.Id);
        if (book == null)
        {
            return false;
        }
        try
        {
            await unitOfWork.RemoveAsync(book);
            await unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception)
        {
            return null;
        }
    }
}