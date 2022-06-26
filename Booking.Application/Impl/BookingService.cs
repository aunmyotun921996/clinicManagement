using Booking.Application.Factory;
using Booking.Application.Mapper;
using Booking.DataAccess.Repositories;
using Booking.Domain;
using Booking.Http;

namespace Booking.Application.Impl
{
    public class BookingService:IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IPatientServiceApi _patientServiceApi;
        public BookingService(IBookingRepository bookingRepository, IPatientServiceApi patientServiceApi)
        {
            _bookingRepository = bookingRepository;
            _patientServiceApi = patientServiceApi;
        }

        public async Task<ServiceResponse<List<Domain.Booking>>> GetAllBookings()
        {
            var bookings=await _bookingRepository.GetAllBookings();

            var patientIds=bookings.Select(x=>x.PatientId).Distinct().ToList();

            var response =await _patientServiceApi.GetPatientByIds(patientIds);
            if (!response.Success) return new ServiceResponse<List<Domain.Booking>>(false, response.Message);

            var patients = response.Result;
            var bookingList = bookings.Select(x => new BookingMapper().ToDomain(x)).ToList();

            var permission = bookingList
                .GroupJoin(
                    patients,
                    b => b.PatientId,
                    p => p.PatientId,
                    (b, p) => new { b, p }
                )
                .SelectMany(
                    x => x.p.DefaultIfEmpty(),
                    (employee, address) =>
                    {
                        var domain = employee.b;
                        var name = address==null? string.Empty :address.PatientName;
                        if (name != null) domain.SetPatientName(name);
                        return domain;
                    }

                );


            return new ServiceResponse<List<Domain.Booking>>(true, "Success", permission.ToList());
        }

        public async Task<ServiceResponse<Domain.Booking>> AddBooking(int patientId, DateTime bookingDate, int tokenNo, int doctorId, string description)
        {
            if (patientId == 0) return new ServiceResponse<Domain.Booking>(false, "Invalid Patient");
            if (tokenNo == 0) return new ServiceResponse<Domain.Booking>(false, "Invalid TokenNo");
            if (doctorId == 0) return new ServiceResponse<Domain.Booking>(false, "Invalid Doctor");

            var booking = new BookingFactory().CreateBooking(patientId, bookingDate, tokenNo, doctorId, description);

            var bookingDb = new BookingMapper().ToDbObject(booking);
            var isAdded=await _bookingRepository.AddBooking(bookingDb);
            return new ServiceResponse<Domain.Booking>(true, "Success", new BookingMapper().ToDomain(isAdded));

        }
    }
}
