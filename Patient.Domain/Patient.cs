using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Patient:DomainObject
    {
        [Key]
        public int PatientId { get;protected set; }
        [Required]
        [StringLength(20)]
        public string PatientName { get;protected set; } 
        [Required]
        [StringLength(10)]
        public string Gender { get;protected set; } 
        [Required]
        public DateTime DateOfBirth { get;protected set; }
        [StringLength(15)]
        public string PhoneNumber { get;protected set; }

        public Patient(int patientId, string patientName, string gender, DateTime dateOfBirth, string phoneNumber)
        {
            PatientId = patientId;
            PatientName = patientName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
        }
    }
}
