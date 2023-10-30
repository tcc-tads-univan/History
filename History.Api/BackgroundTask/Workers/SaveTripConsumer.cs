using History.Api.Mapping;
using History.Api.Services;
using MassTransit;
using RabbitMQ.Client;
using SharedContracts;
using SharedContracts.Events;

namespace History.Api.BackgroundTask.Workers
{
    public class SaveTripConsumer : IConsumer<SaveTripEvent>
    {
        private readonly IHistoryService _historyService;
        private readonly ILogger<SaveTripConsumer> _logger;
        public SaveTripConsumer(IHistoryService historyService, ILogger<SaveTripConsumer> logger)
        {
            _historyService = historyService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<SaveTripEvent> context)
        {
            var trip = context.Message.ToTrip();
            await _historyService.SaveTrip(trip);

            _logger.LogInformation("SaveTripEvent consumed successfully!");
        }
    }

    public class SaveTripConsumerDefinition : ConsumerDefinition<SaveTripConsumer>
    {
        public SaveTripConsumerDefinition()
        {
            EndpointName = "save-trip";
        }
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<SaveTripConsumer> consumerConfigurator, IRegistrationContext context)
        {
            if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rabbit)
            {
                rabbit.ConfigureConsumeTopology = false;
                rabbit.Bind(BaseCarpoolEvent.exchageName, s =>
                {
                    s.RoutingKey = "SaveTripEvent";
                    s.ExchangeType = ExchangeType.Direct;
                });
            }
        }
    }
}
