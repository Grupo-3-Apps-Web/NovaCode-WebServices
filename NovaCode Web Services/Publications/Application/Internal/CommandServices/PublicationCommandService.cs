using Cortex.Mediator;
using NovaCode_Web_Services.Publications.Domain.Model.Aggregate;
using NovaCode_Web_Services.Publications.Domain.Model.Commands;
using NovaCode_Web_Services.Publications.Domain.Repositories;
using NovaCode_Web_Services.Publications.Domain.Services;
using NovaCode_Web_Services.Shared.Domain.Model.Events;
using NovaCode_Web_Services.Shared.Domain.Repositories;

namespace NovaCode_Web_Services.Publications.Application.Internal.CommandServices;

public class PublicationCommandService(IPublicationRepository publicationRepository, IUnitOfWork unitOfWork, IMediator mediator) : IPublicationCommandService
{
    public async Task<Publication> Handle(CreatePublicationCommand command)
    {
        var publication = new Publication(command.Model, command.Brand, command.Year, command.Description, 
            command.Image, command.Price, command.PublishedDate);
        try
        {
            await publicationRepository.AddAsync(publication);
            await unitOfWork.CompleteAsync();
            
            var publicationCreatedEvent = new PublicationCreatedEvent(
                publication.Id,
                publication.Model,
                publication.Brand,
                publication.Year,
                publication.Description,
                publication.Image,
                publication.Price,
                publication.PublishedDate);
            await mediator.PublishAsync(publicationCreatedEvent);
            return publication;
        }
        catch (Exception ex)
        {
            throw new Exception("Error creating new publication", ex);
        }
    }
    
    public async Task<Publication?> Handle(int id, UpdatePublicationCommand command)
    {
        var publication = await publicationRepository.FindByIdAsync(id);

        if (publication == null)
        {
            return null;
        }

        publication.UpdatePublication(command.Model, command.Brand, command.Year, command.Description, 
            command.Image, command.Price, command.PublishedDate);
        try
        {
            await unitOfWork.UpdateAsync(publication);
            await unitOfWork.CompleteAsync();

            return publication;
        }
        catch (Exception ex)
        {
            throw new Exception("Error updating publication info", ex);
        }
    }
    
    public async Task<bool?> Handle(DeletePublicationCommand command)
    {
        var publication = await publicationRepository.FindByIdAsync(command.Id);

        if (publication == null)
        {
            return false;
        }

        try
        {
            await unitOfWork.RemoveAsync(publication);
            await unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception)
        {
            return null;
        }
    }
}