using NovaCode_Web_Services.Dashboard.Domain.Model.Aggregate;
using NovaCode_Web_Services.Dashboard.Domain.Model.Queries;

namespace NovaCode_Web_Services.Dashboard.Domain.Services;

public interface IBookQueryService
{
    Task<IEnumerable<Book>> Handle(GetAllBookQuery query);
    
}