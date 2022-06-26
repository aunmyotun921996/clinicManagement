using Application.Factory;
using Application.Mapper;
using Application.Response.Dto;
using Application.Response.Mapper;
using DataAccess;
using Domain;

namespace Application
{
    public interface IPatientService
    {
        public Task<ServiceResponse<PatientDto>> AddNewPatient(string patientName,string gender,DateTime dateOfBirth,string phoneNumber);
        public Task<ServiceResponse<List<PatientDto>>> GetAllPatients();
        public Task<ServiceResponse<List<PatientDto>>> GetPatientByIds(List<int>patientIds);
    }
    public class PatientService: IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<ServiceResponse<PatientDto>> AddNewPatient(string patientName, string gender, DateTime dateOfBirth, string phoneNumber)
        {
            if (string.IsNullOrEmpty(patientName)) return new ServiceResponse<PatientDto>(false, "Patient Name is required!");
            if (string.IsNullOrEmpty(gender)) return new ServiceResponse<PatientDto>(false, "Gender is required!");
            if (dateOfBirth.Date == DateTime.Now.Date)
                return new ServiceResponse<PatientDto>(false, "Invalid DateOfBirth");

            var patient = new PatientFactory().CreatePatient(patientName, gender, dateOfBirth, phoneNumber);
            var patientDb =await _patientRepository.AddPatient(new PatientMapper().ToDbObject(patient));

            var patientDomain = new PatientMapper().ToDomain(patientDb);
            return new ServiceResponse<PatientDto>(true,"Success",new PatientDtoMapper().ToDto(patientDomain));
        }

        public async Task<ServiceResponse<List<PatientDto>>> GetAllPatients()
        {
            var patients = await _patientRepository.GetAllPatients();
            var patientDomainList = patients.Select(x => new PatientMapper().ToDomain(x)).ToList();
            var results= patientDomainList.Select(x => new PatientDtoMapper().ToDto(x)).ToList();
            return new ServiceResponse<List<PatientDto>>(true,"Success",results);
        }

        public async Task<ServiceResponse<List<PatientDto>>> GetPatientByIds(List<int> patientIds)
        {
            var patients = await _patientRepository.GetPatientByIds(patientIds);
            var patientDomainList = patients.Select(x => new PatientMapper().ToDomain(x)).ToList();
            var results = patientDomainList.Select(x => new PatientDtoMapper().ToDto(x)).ToList();
            return new ServiceResponse<List<PatientDto>>(true, "Success", results);
        }
    }
}
