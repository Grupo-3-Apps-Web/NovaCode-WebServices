using Cortex.Mediator.Notifications;
using NovaCode_Web_Services.Dashboard.Domain.Model.Aggregate;
using NovaCode_Web_Services.Dashboard.Domain.Repositories;
using NovaCode_Web_Services.Shared.Domain.Model.Events;

namespace NovaCode_Web_Services.Dashboard.Application.Internal.EventHandlers;

public class VehiclesReservedEventHandler(IBookRepository bookRepository) : INotificationHandler<VehicleReservedEvent>
{
    public async Task Handle(VehicleReservedEvent domainEvent, CancellationToken cancellationToken)
    {
        var book = new Book
        {
            VehicleId = domainEvent.VehicleId,
            UserId = domainEvent.UserId,
            ReservedAt = domainEvent.ReservedAt,
            Model = domainEvent.Model,
            Brand = domainEvent.Brand,
            Year = domainEvent.Year,
            Description = domainEvent.Description,
            Image = domainEvent.Image,
            Price = domainEvent.Price,
            PublishedDate = domainEvent.PublishedDate,

        };
        await bookRepository.AddAsync(book);
    }
}