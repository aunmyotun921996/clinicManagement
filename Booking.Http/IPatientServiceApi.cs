using Booking.Http.Response;

namespace Booking.Http
{
    public interface IPatientServiceApi
    {
        Task<ApiResponse<List<Patient>>> GetPatientByIds(List<int> ids);
    }
}
