using Booking.DataAccess.Models;
using Booking.Domain;

namespace Booking.Application.Mapper
{
    public interface IMapper<TDomainObject, TDbObject>
        where TDomainObject : DomainObject
        where TDbObject : EntityBase
    {
        TDomainObject ToDomain(TDbObject dbObject);
        TDbObject ToDbObject(TDomainObject domainObject);
    }
}
