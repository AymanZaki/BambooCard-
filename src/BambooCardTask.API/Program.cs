using Core.Interfaces;
using Core.Services;
using Gateway.Interfaces;
using Gateway.Services;
using Models;
using Models.ConfigKeys;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<HackerNewsConfigs>(configuration.GetSection("HackerNews"));

#region Inject Core
builder.Services.AddScoped<IStoriesCore, StoriesCore>();
#endregion


#region Inject Gateway
builder.Services.AddScoped<IHackerNewsAPIs, HackerNewsAPIs>();
#endregion

#region HttpClient
builder.Services.AddHttpClient(HttpClients.HackerNewsHttpClientName, client =>
{
    client.BaseAddress = new Uri(configuration["HackerNews:BaseUrl"]);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
    client.DefaultRequestHeaders.Add("User-Agent", "BambooCard-API");
});

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
