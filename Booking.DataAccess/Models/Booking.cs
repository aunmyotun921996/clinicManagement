using System.ComponentModel.DataAnnotations;

namespace Booking.DataAccess.Models
{
    public class Booking:EntityBase
    {
        [Key]
        public int BookingId { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required]
        public DateTime BookingDate { get; set; }
        [Required]
        public int TokenNo { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [StringLength(200)]
        public string Description { get; set; } = string.Empty;
    }
}
