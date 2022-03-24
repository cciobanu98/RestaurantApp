using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Users.Domain;

namespace Users.Api.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly DaprClient _daprClient;
        private const string storeName = "user-state-store";
        public UserController(DaprClient daprClient)
        {
            _daprClient = daprClient;
        }

        [HttpGet]
        public async Task<ActionResult<UserOrder>> GetByName(string orderName)
        {
            var item = await _daprClient.GetStateAsync<UserOrder>(storeName, orderName);
            return Ok(item);
        }
    }
}
