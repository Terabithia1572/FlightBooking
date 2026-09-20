using FlightBooking.DTOs.CheckinDTOs;

namespace FlightBooking.Services.CheckInServices
{
    public interface ICheckInService
    {
        Task CompleteCheckInAsync(CompleteCheckInDTO dto);
    }
}
