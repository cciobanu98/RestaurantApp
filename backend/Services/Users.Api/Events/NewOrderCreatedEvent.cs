using EventBus.Events;

namespace Users.Api.Events
{
    public record NewOrderCreatedEvent(string Name, string ItemName) : IntegrationEvent;
}
