using Users.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddDapr();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.AddCustomApplicationServices();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCloudEvents();
app.UseAuthorization();

app.MapControllers();
app.MapSubscribeHandler();
app.Run();
