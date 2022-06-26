

using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Impl
{
    public class PatientRepository: IPatientRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PatientRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose() => _dbContext.Dispose();

        public async Task<List<Patient>> GetAllPatients()
        {
            var patients = await _dbContext.Patients.ToListAsync();
            return patients;
        }

        public async Task<List<Patient>> GetPatientByIds(List<int> patientIds)
        {
            try
            {
                return await _dbContext.Patients.Where(x=>patientIds.Contains(x.PatientId)).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<Patient> AddPatient(Patient patient)
        {
            await _dbContext.Patients.AddAsync(patient);
            var isAdded = await _dbContext.SaveChangesAsync();
            return isAdded>0 ?patient:new Patient();
        }

        public async Task<Patient?> GetPatient(int patientId)
        {
            var patient=await _dbContext.Patients.FindAsync(patientId);
            return patient;
        }
    }
}
