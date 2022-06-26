using Booking.Application;
using Booking.Host.Models;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Host.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllBooking()
        {
            return Ok(await _bookingService.GetAllBookings());
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddBooking(BookingModel booking)
        {
            return Ok(await _bookingService.AddBooking(booking.PatientId,booking.BookingDate,booking.TokenNo,booking.DoctorId,booking.Description));
        }
    }
}
