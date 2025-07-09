using Cortex.Mediator.Notifications;
using NovaCode_Web_Services.Navigation.Domain.Model.Aggregate;
using NovaCode_Web_Services.Navigation.Domain.Repositories;
using NovaCode_Web_Services.Shared.Domain.Model.Events;

namespace NovaCode_Web_Services.Navigation.Application.Internal.EventHandlers;

public class PublicationCreatedEventHandler(IVehicleRepository vehicleRepository) : INotificationHandler<PublicationCreatedEvent>
{
    public async Task Handle(PublicationCreatedEvent domainEvent, CancellationToken cancellationToken)
    {
        var vehicle = new Vehicle(domainEvent.Id, domainEvent.Model, domainEvent.Brand, domainEvent.Year, domainEvent.Description,
            domainEvent.Image, domainEvent.Price, domainEvent.PublishedDate);
        await vehicleRepository.AddAsync(vehicle);
    }
}