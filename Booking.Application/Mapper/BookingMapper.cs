namespace Booking.Application.Mapper
{
    public class BookingMapper:IMapper<Domain.Booking,DataAccess.Models.Booking>
    {
        public Domain.Booking ToDomain(DataAccess.Models.Booking dbObject)
        {
            return new Domain.Booking(dbObject.BookingId, dbObject.PatientId, dbObject.BookingDate, dbObject.TokenNo,
                dbObject.DoctorId, dbObject.Description);
        }

        public DataAccess.Models.Booking ToDbObject(Domain.Booking domainObject)
        {
            return new DataAccess.Models.Booking
            {
                PatientId = domainObject.PatientId,
                BookingDate = domainObject.BookingDate,
                TokenNo = domainObject.TokenNo,
                DoctorId = domainObject.DoctorId,
                Description = domainObject.Description
            };
        }
    }
}
