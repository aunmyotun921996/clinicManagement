using Application.Response.Dto;
using Domain;

namespace Application.Response.Mapper
{
    public class PatientDtoMapper:IDtoMapper<Patient,PatientDto>
    {
        public PatientDto ToDto(Patient domainObject)
        {
            return new PatientDto(domainObject.PatientId, domainObject.PatientName, domainObject.Gender,
                domainObject.DateOfBirth, domainObject.PhoneNumber);
        }
    }
}
