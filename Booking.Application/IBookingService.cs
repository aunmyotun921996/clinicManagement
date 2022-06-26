using Booking.Domain;

namespace Booking.Application
{
    public interface IBookingService
    {
        public Task<ServiceResponse<List<Domain.Booking>>> GetAllBookings();
        public Task<ServiceResponse<Domain.Booking>> AddBooking(int patientId, DateTime bookingDate, int tokenNo,
            int doctorId, string description);
    }
}
