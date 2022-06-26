namespace Booking.Domain
{
    public record Booking:DomainObject
    {
        public int BookingId { get;protected set; }
        public int PatientId { get;protected set; }
        public DateTime BookingDate { get;protected set; }
        public int TokenNo { get; protected set; }
        public int DoctorId { get;protected set; }
        public string Description { get;protected set; }
        public string? PatientName { get; protected set; }

        public Booking(int bookingId, int patientId, DateTime bookingDate, int tokenNo, int doctorId, string description)
        {
            BookingId = bookingId;
            PatientId = patientId;
            BookingDate = bookingDate;
            TokenNo = tokenNo;
            DoctorId = doctorId;
            Description = description;
        }

        public void SetPatientName(string patientName)
        {
            PatientName=patientName;
        }
    }
}
