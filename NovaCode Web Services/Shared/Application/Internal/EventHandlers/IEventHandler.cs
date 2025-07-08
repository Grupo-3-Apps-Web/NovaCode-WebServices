using NovaCode_Web_Services.Shared.Domain.Model.Events;
using Cortex.Mediator.Notifications;

namespace NovaCode_Web_Services.Shared.Application.Internal.EventHandlers;

public interface IEventHandler< in TEvent> : INotificationHandler<TEvent> where TEvent : IEvent
{
    
}