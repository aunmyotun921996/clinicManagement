namespace Booking.DataAccess.Repositories
{
    public interface IBookingRepository:IDisposable
    {
        public Task<List<Models.Booking>> GetAllBookings();
        public Task<Models.Booking>AddBooking(Models.Booking booking);
    }
}
