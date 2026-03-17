class Appointment
{
    public void ScheduleAppointment(string patient)
    {
        Console.WriteLine($"Appointment scheduled for {patient}");
    }

    public void ScheduleAppointment(string patient, DateTime date)
    {
        Console.WriteLine($"{patient} on {date}");
    }

    public void ScheduleAppointment(string patient, DateTime date, string mode = "Offline")
    {
        Console.WriteLine($"{patient} on {date} via {mode}");
    }
}
