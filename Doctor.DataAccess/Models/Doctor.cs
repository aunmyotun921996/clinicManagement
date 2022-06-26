using System.ComponentModel.DataAnnotations;

namespace Doctor.DataAccess.Models
{
    public class EntityBase
    {

    }
    public class Doctor:EntityBase
    {
        [Key]
        public int DoctorId { get; set; }
        [Required]
        [StringLength(100)]
        public string DoctorName { get; set; } = string.Empty;
        public int ShiftId { get; set; }
        public double Fees { get; set; }
        [StringLength(500)]
        public string Remark { get; set; }=string.Empty;
        public DateTime CreatedDate { get; set; }

    }
}
