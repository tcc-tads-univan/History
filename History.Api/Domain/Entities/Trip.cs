﻿namespace History.Api.Database.Entities
{
    public class Trip
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int DriverId { get; set; }
        public string DriverName { get; set; }
        public string InitialDestination { get; set; }
        public string FinalDestination { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public int ScheduleId { get; set; }
        public string Status { get; set; }
    }
}
