using History.Api.BackgroundTask.Workers;
using History.Api.Database;
using History.Api.Database.Interfaces;
using History.Api.Repository;
using History.Api.Services;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var config = builder.Configuration;
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IDbConnectionFactory>(_ => new DbConnectionFactory(config.GetConnectionString("HistoryDatabase")));
builder.Services.AddScoped<IHistoryRepository, HistoryRepository>();
builder.Services.AddScoped<IHistoryService, HistoryService>();

builder.Host.ConfigureServices((hostContext, services) =>
{
    services.AddMassTransit(x =>
    {
        x.AddConsumer<SaveTripConsumer>(typeof(SaveTripConsumerDefinition));
        x.AddConsumer<CompleteTripConsumer>();

        x.SetKebabCaseEndpointNameFormatter();

        x.UsingRabbitMq((context, busFactoryConfigurator) =>
        {
            busFactoryConfigurator.Host(config.GetConnectionString("RabbitMq"));
            busFactoryConfigurator.ConfigureEndpoints(context);
        });
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
