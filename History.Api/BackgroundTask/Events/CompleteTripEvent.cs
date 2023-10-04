namespace History.Api.BackgroundTask.Events
{
    public class CompleteTripEvent
    {
        public int DriverId { get; set; }
        public int StudentId { get; set; }
    }
}
