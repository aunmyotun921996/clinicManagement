using Domain;

namespace Application.Mapper
{
    public class PatientMapper : IMapper<Patient, DataAccess.Data.Patient>
    {
        public Patient ToDomain(DataAccess.Data.Patient dbObject)
        {
            return new Patient(dbObject.PatientId, dbObject.PatientName, dbObject.Gender, dbObject.DateOfBirth,
                dbObject.PhoneNumber);
        }
        public DataAccess.Data.Patient ToDbObject(Patient domainObject)
        {
            return new DataAccess.Data.Patient
            {
                PatientName = domainObject.PatientName,
                Gender = domainObject.Gender,
                DateOfBirth = domainObject.DateOfBirth,
                PhoneNumber = domainObject.PhoneNumber
            };
        }
    }
}
