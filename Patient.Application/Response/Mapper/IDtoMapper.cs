using Domain;

namespace Application.Response.Mapper
{
    public interface IDtoMapper<in TDomainObject, out TDto>
        where TDomainObject : DomainObject
        where TDto : Dto.Dto
    {
        TDto ToDto(TDomainObject domainObject);
    }
}
