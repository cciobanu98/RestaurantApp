using Dapr.Client;
using Menu.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Menu.Api.Controllers
{
    [ApiController]
    [Route("menu")]
    public class MenuController : ControllerBase
    {
        private readonly DaprClient _daprClient;
        private const string storeName = "menu-state-store";

        public MenuController(DaprClient daprClient)
        {
            _daprClient = daprClient;
        }

        [HttpGet]
        public async Task<ActionResult<MenuData>> GetMenuByName(string name)
        {
            var menu = await _daprClient.GetStateAsync<MenuData>(storeName, name);
            return Ok(menu);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMenu(string name)
        {
            var menu = new MenuData() { Name = name };
            await _daprClient.SaveStateAsync(storeName, name, menu);
            return Ok(menu);
        }
    }
}
