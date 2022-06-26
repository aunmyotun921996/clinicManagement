
namespace Booking.Application.Factory
{
    public class BookingFactory
    {
        public virtual Domain.Booking CreateBooking(int patientId, DateTime bookingDate, int tokenNo,int doctorId, string description)
        {
            return new Domain.Booking(0, patientId, bookingDate, tokenNo, doctorId, description);
        }
    }
}
