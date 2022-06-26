using System.ComponentModel.DataAnnotations;

namespace Host.Models
{
    public class PatientModel
    {
        public int PatientId { get;  set; }
        [Required] [StringLength(20)] public string PatientName { get; set; } = string.Empty;
        [Required] [StringLength(10)] public string Gender { get; set; }=string.Empty;
        [Required] public DateTime DateOfBirth { get;  set; }
        [StringLength(15)] public string PhoneNumber { get; set; }= string.Empty;
    }
}
