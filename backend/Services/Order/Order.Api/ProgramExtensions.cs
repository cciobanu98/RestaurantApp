using EventBus;
using EventBus.Abstractions;

namespace Order.Api
{
    public static class ProgramExtensions
    {
        public static void AddCustomApplicationServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IEventBus, DaprEventBus>();
        }
    }
}
