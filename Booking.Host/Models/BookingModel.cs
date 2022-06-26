namespace Booking.Host.Models
{
    public record BookingModel
    {
        public int BookingId { get; set; }
        public int PatientId { get; set; }
        public DateTime BookingDate { get; set; }
        public int TokenNo { get; set; }
        public int DoctorId { get; set; }
        public string Description { get; set; }
    }
}
