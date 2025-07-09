using NovaCode_Web_Services.Dashboard.Domain.Model.Aggregate;
using NovaCode_Web_Services.Dashboard.Domain.Model.Queries;
using NovaCode_Web_Services.Dashboard.Domain.Repositories;
using NovaCode_Web_Services.Dashboard.Domain.Services;

namespace NovaCode_Web_Services.Dashboard.Application.Internal.QueryService;

public class BookQueriesService(IBookRepository bookRepository): IBookQueryService
{
    public async Task<IEnumerable<Book>> Handle(GetAllBookQuery query)
    {
        return await bookRepository.ListAsync();
    }
}