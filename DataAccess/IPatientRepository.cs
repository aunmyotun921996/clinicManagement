using DataAccess.Data;
namespace DataAccess
{
    public interface IPatientRepository:IDisposable
    {
        public Task<List<Patient>> GetAllPatients();
        public Task<List<Patient>> GetPatientByIds(List<int> patientIds);
        public Task<Patient>AddPatient(Patient patient);
        public Task<Patient?> GetPatient(int patientId);
    }
}
