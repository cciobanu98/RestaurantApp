using EventBus.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Order.Api.Events;
using Order.Domain;

namespace Order.Api.Controllers
{
    [ApiController]
    [Route("order")]
    public class OrderController : ControllerBase
    {
        private readonly IEventBus _eventBus;

        public OrderController(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] OrderItem order)
        {
            await _eventBus.PublishAsync(new NewOrderCreatedEvent(order.Name, order.ItemName));   
            return Ok();
        }
    }
}
