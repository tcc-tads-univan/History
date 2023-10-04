using History.Api.BackgroundTask.Events;
using History.Api.Services;
using MassTransit;

namespace History.Api.BackgroundTask.Workers
{
    public class CompleteTripConsumer : IConsumer<CompleteTripEvent>
    {
        private readonly IHistoryService _historyService;
        private readonly ILogger<CompleteTripConsumer> _logger;
        public CompleteTripConsumer(IHistoryService historyService, ILogger<CompleteTripConsumer> logger)
        {
            _historyService = historyService;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<CompleteTripEvent> context)
        {
            await _historyService.CompleteTrip(context.Message.StudentId, context.Message.DriverId);

            _logger.LogInformation("CompleteTripEvent consumed successfully.");
        }
    }
}
