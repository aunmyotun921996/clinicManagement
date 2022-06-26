namespace Booking.Http.Response
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string? PatientName { get; set; }
        public string? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
