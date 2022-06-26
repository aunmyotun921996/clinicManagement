using DataAccess.Data;
using Domain;

namespace Application.Mapper
{
    public interface IMapper<TDomainObject, TDbObject>
    where TDomainObject : DomainObject
    where TDbObject : EntityBase
    {
        TDomainObject ToDomain(TDbObject dbObject);
        TDbObject ToDbObject(TDomainObject domainObject);
    }
}
