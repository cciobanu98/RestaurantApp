using Dapr;
using Microsoft.AspNetCore.Mvc;
using Users.Api.Events;

namespace Users.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class IntegrationEventController : ControllerBase
    {
        private const string DAPR_PUBSUB_NAME = "pubsub";

        [HttpPost("NewOrderCreated")]
        [Topic(DAPR_PUBSUB_NAME, nameof(NewOrderCreatedEvent))]
        public Task HandleAsync(NewOrderCreatedEvent @event, [FromServices] NewOrderCreatedEventHandler handler) => handler.Handle(@event);
    }
}
