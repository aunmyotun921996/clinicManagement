using System.ComponentModel.DataAnnotations;

namespace DataAccess.Data
{
    public class Patient:EntityBase
    {
        [Key] public int PatientId { get; set; }
        [Required] [StringLength(20)] public string PatientName { get; set; } = string.Empty;
        [Required] [StringLength(10)] public string Gender { get; set; } = string.Empty;
        [Required] public DateTime DateOfBirth { get; set; }
        [StringLength(15)] public string PhoneNumber { get; set; } = string.Empty;
    }
}
