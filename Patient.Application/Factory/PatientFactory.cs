using Domain;

namespace Application.Factory
{
    internal class PatientFactory
    {
        public Patient CreatePatient(string patientName, string gender, DateTime dateOfBirth, string phoneNumber)
        {
            return new Patient(0, patientName, gender, dateOfBirth, phoneNumber);
        }
    }
}
