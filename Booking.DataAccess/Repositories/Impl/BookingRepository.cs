using Microsoft.EntityFrameworkCore;

namespace Booking.DataAccess.Repositories.Impl
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingDbContext _dbContext;

        public BookingRepository(BookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Dispose() => _dbContext.Dispose();

        public async Task<List<Models.Booking>> GetAllBookings()
        {
            try
            {
                return await _dbContext.Bookings.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<Models.Booking> AddBooking(Models.Booking booking)
        {
            if (booking == null)
            {
                throw new ArgumentNullException($"{nameof(AddBooking)} entity must not be null");
            }
            try
            {
                await _dbContext.AddAsync(booking);
                await _dbContext.SaveChangesAsync();
                return booking;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(AddBooking)} could not be saved: {ex.Message}");
            }
        }
    }
}
