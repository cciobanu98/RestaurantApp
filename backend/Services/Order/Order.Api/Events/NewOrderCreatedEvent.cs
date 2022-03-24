using EventBus.Events;

namespace Order.Api.Events
{
    public record NewOrderCreatedEvent(string Name, string ItemName) : IntegrationEvent;
        
}
