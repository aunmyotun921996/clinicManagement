using Microsoft.EntityFrameworkCore;

namespace Booking.DataAccess
{
    public class BookingDbContext:DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext>options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public virtual DbSet<Models.Booking> Bookings => Set<Models.Booking>();
    }
}
