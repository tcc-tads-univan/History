namespace History.Api.Database.Entities
{
    public class Trip
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int StudentName { get; set; }
        public int DriverId { get; set; }
        public int DriverName { get; set; }
        public string InitialDestination { get; set; }
        public string FinalDestination { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}
