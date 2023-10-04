using History.Api.BackgroundTask.Events;
using History.Api.Mapping;
using History.Api.Services;
using MassTransit;

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
}
