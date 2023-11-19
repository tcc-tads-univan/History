using History.Api.Services;
using MassTransit;
using RabbitMQ.Client;
using SharedContracts.Events;

namespace History.Api.BackgroundTask.Workers
{
    public class CompleteTripConsumer : IConsumer<CompleteTripEvent>
    {
        private readonly IHistoryService _historyService;
        private readonly ILogger<SaveTripConsumer> _logger;
        public CompleteTripConsumer(IHistoryService historyService, ILogger<SaveTripConsumer> logger)
        {
            _historyService = historyService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<CompleteTripEvent> context)
        {
            var scheduleId = context.Message.ScheduleId;
            await _historyService.CompleteTrip(scheduleId);

            _logger.LogInformation("CompleteTripEvent consumed successfully!");
        }
    }

    public class CompleteTripConsumerDefinition : ConsumerDefinition<CompleteTripConsumer>
    {
        public CompleteTripConsumerDefinition()
        {
            EndpointName = "complete-trip";
        }
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<CompleteTripConsumer> consumerConfigurator, IRegistrationContext context)
        {
            if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rabbit)
            {
                rabbit.ConfigureConsumeTopology = false;
                rabbit.Bind(BaseCarpoolEvent.exchageName, s =>
                {
                    s.RoutingKey = "CompleteTripEvent";
                    s.ExchangeType = ExchangeType.Direct;
                });
            }
        }
    }
}
