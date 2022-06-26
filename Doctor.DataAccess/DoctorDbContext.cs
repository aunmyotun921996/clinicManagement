using Microsoft.EntityFrameworkCore;

namespace Doctor.DataAccess
{
    public class DoctorDbContext:DbContext
    {
        public DoctorDbContext(DbContextOptions<DoctorDbContext>options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public virtual DbSet<Models.Doctor> Doctors => Set<Models.Doctor>();
    }
}
