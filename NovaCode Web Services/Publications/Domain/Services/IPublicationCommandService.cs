using NovaCode_Web_Services.Publications.Domain.Model.Aggregate;
using NovaCode_Web_Services.Publications.Domain.Model.Commands;

namespace NovaCode_Web_Services.Publications.Domain.Services;

public interface IPublicationCommandService
{
    Task <Publication> Handle(CreatePublicationCommand command);
    Task<Publication> Handle(int id, UpdatePublicationCommand command);
    Task<bool?> Handle(DeletePublicationCommand command);
    
}