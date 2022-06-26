namespace Application.Response.Dto
{
    public record PatientDto:Dto
    {
        public int PatientId { get; protected set; }
        public string PatientName { get; protected set; }
        public string Gender { get; protected set; }
        public DateTime DateOfBirth { get; protected set; }
        public string PhoneNumber { get; protected set; }

        public PatientDto(int patientId, string patientName, string gender, DateTime dateOfBirth, string phoneNumber)
        {
            PatientId = patientId;
            PatientName = patientName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
        }
    }
}
