namespace History.Api.BackgroundTask.Events
{
    public class SaveTripEvent
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int DriverId { get; set; }
        public string DriverName { get; set; }
        public string InitialDestination { get; set; }
        public string FinalDestination { get; set; }
        public decimal Price { get; set; }
    }
}
