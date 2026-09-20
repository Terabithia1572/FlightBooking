using FlightBooking.DTOs.BookingDTOs;

namespace FlightBooking.Services.BookingServices
{
    public interface IBookingService
    {
        Task CreateBookingAsync(CreateBookingDTO dto);
        Task<(string Name, string Surname)> GetPassengerNameByIdAsync(string passengerId);
    }
}
