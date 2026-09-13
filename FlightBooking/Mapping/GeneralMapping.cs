using AutoMapper;
using FlightBooking.DTOs.FlightDTOs;
using FlightBooking.Entites;

namespace FlightBooking.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Flight, CreateFlightDTO>().ReverseMap();
            CreateMap<Flight, ResultFlightDTO>().ReverseMap();
            CreateMap<Flight, UpdateFlightDTO>().ReverseMap();
            CreateMap<Flight, GetFlightByIDDTO>().ReverseMap();
        }
    }
}
