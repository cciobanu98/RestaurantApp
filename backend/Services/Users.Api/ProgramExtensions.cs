using EventBus;
using EventBus.Abstractions;
using Users.Api.Events;

namespace Users.Api
{
    public static class ProgramExtensions
    {
        public static void AddCustomApplicationServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IEventBus, DaprEventBus>();
            builder.Services.AddScoped<NewOrderCreatedEventHandler>();
        }
    }
}
