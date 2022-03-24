using Dapr.Client;
using EventBus.Abstractions;
using Microsoft.AspNetCore.WebUtilities;
using Users.Domain;

namespace Users.Api.Events
{
    public class NewOrderCreatedEventHandler : IIntegrationEventHandler<NewOrderCreatedEvent>
    {
        private readonly DaprClient _daprClient;
        private const string storeName = "user-state-store";

        public NewOrderCreatedEventHandler(DaprClient daprClient)
        {
            _daprClient = daprClient;
        }

        public async Task Handle(NewOrderCreatedEvent @event)
        {
            var request = _daprClient.CreateInvokeMethodRequest(HttpMethod.Get, "menu-service", $"menu/by-name?name={@event.ItemName}");
            var itemId = await _daprClient.InvokeMethodAsync<int>(request);
            var userOrder = new UserOrder() { OrderName = @event.Name, MenuItemId = itemId };
            await _daprClient.SaveStateAsync(storeName, @event.Name, userOrder);
        }
    }
}
