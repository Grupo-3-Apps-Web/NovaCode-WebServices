using NovaCode_Web_Services.Dashboard.Domain.Model.Aggregate;
using NovaCode_Web_Services.Dashboard.Domain.Repositories;
using NovaCode_Web_Services.Shared.Infrastructure.Persistence.EFC.Configuration;
using NovaCode_Web_Services.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace NovaCode_Web_Services.Dashboard.Infrastructure.Persistence.EFC.Repositories;

public class BookRepository(AppDbContext context):BaseRepository<Book>(context), IBookRepository
{
    
}