using AutoMapper;
using FlightBooking.DTOs.FlightDTOs;
using FlightBooking.DTOs.PassengerDTOs;
using FlightBooking.Entites;
using FlightBooking.Settings;
using MongoDB.Driver;

namespace FlightBooking.Services.FlightServices
{
    public class FlightService : IFlightService // FlightService sınıfını IFlightService arayüzünden türettik.
    {
        private readonly IMapper _mapper; // IMapper arayüzünü kullanmak için _mapper alanını tanımladık.
        private readonly IMongoCollection<Flight> _flightCollection; // IMongoCollection<Flight> türünde _flightCollection alanını tanımladık. Bu alan, Flight koleksiyonunu temsil eder.
        private readonly IMongoCollection<Booking> _bookingCollection; // IMongoCollection<Booking> türünde _bookingCollection alanını tanımladık. Bu alan, Booking koleksiyonunu temsil eder.

        public FlightService(IMapper mapper,IDatabaseSettings _databaseSettings, IMongoCollection<Booking> bookingCollection) // Constructor'ı FlightService sınıfına ekledik ve IMapper ile IDatabaseSettings parametrelerini aldık.
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); // MongoClient sınıfını kullanarak MongoDB bağlantısını oluşturduk.
            var database = client.GetDatabase(_databaseSettings.DatabaseName); // GetDatabase metodu ile belirtilen veritabanını aldık.
            _flightCollection = database.GetCollection<Flight>(_databaseSettings.FlightCollectionName); // GetCollection metodu ile Flight koleksiyonunu aldık.
            _mapper = mapper; // IMapper örneğini _mapper alanına atadık.
            _bookingCollection = bookingCollection;
        }

        public async Task CreateFlightAsync(CreateFlightDTO createFlightDto) // CreateFlightAsync metodunu implement ettik. Uçuş oluşturma işlemi için CreateFlightDTO parametresini alır.
        {
            var values=_mapper.Map<Flight>(createFlightDto); // AutoMapper kullanarak CreateFlightDTO nesnesini Flight nesnesine dönüştürdük.
            await _flightCollection.InsertOneAsync(values); // InsertOneAsync metodu ile Flight koleksiyonuna yeni uçuşu ekledik.
        }

        public async Task DeleteFlightAsync(string id) // DeleteFlightAsync metodunu implement ettik. Silme işlemi için uçuş ID'sini parametre olarak alır.
        {
           await _flightCollection.DeleteOneAsync(flight => flight.FlightId == id); // DeleteOneAsync metodu ile belirtilen ID'ye sahip uçuşu Flight koleksiyonundan sildik.
        }

        public async Task<List<ResultFlightDTO>> GetAllFlightsAsync() // GetAllFlightsAsync metodunu implement ettik. Tüm uçuşları listelemek için kullanılır.
        {
            var values= await _flightCollection.Find(flight => true).ToListAsync(); // Find metodu ile tüm uçuşları alıp listeledik.
            return _mapper.Map<List<ResultFlightDTO>>(values); // AutoMapper kullanarak Flight nesnelerini ResultFlightDTO nesnelerine dönüştürdük ve döndürdük.
        }

        public async Task<GetFlightByIDDTO> GetFlightByIdAsync(string id) // GetFlightByIdAsync metodunu implement ettik. Belirli bir uçuşu ID'sine göre almak için kullanılır.
        {
            //var values = await _flightCollection.Find(flight => flight.FlightId == id).FirstOrDefaultAsync(); // Find metodu ile belirtilen ID'ye sahip uçuşu aldık.
            //return _mapper.Map<GetFlightByIDDTO>(values); // AutoMapper kullanarak Flight nesnesini GetFlightByIDDTO nesnesine dönüştürdük ve döndürdük.

            var value = await _flightCollection.Find(x => x.FlightId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetFlightByIDDTO>(value);
        }

        public async Task<List<PassengerListItemDTO>> GetFlightDetailsWithPassengers(string id)
        {
            // 1. O uçuşa ait tüm booking'leri çek
            var bookings = await _bookingCollection.Find(x => x.FlightId == id).ToListAsync();

            // 2. Her booking içindeki yolcuları düzleştir ve DTO'ya map et
            var passengers = bookings
                .SelectMany(b => b.Passengers.Select(p => new PassengerListItemDTO
                {
                    Name = p.Name,
                    Surname = p.Surname,
                    Email = b.ContactEmail,   // yolcuya ait email yoksa iletişim emaili kullan
                    Gender = p.Gender,
                    PassengerType = p.PassengerType,
                    PnrNumber = b.PnrNumber,       // PNR olarak BookingId kullanılıyor
                    Phone = b.ContactPhone,
                    // Aşağıdaki alanlar Passenger entity'nde varsa doğrudan al
                    SeatNumber = p.SeatNumber,
                    CheckInStatus = p.CheckInStatus,
                    // PaymentStatus = b.PaymentStatus,
                    TicketStatus = p.TicketStatus,
                    PassengerId = p.PassengerId
                }))
                .ToList();

            return passengers;
        }

        public async Task UpdateFlightAsync(UpdateFlightDTO updateFlightDto) // UpdateFlightAsync metodunu implement ettik. Uçuş güncelleme işlemi için UpdateFlightDTO parametresini alır.
        {
            var values =_mapper.Map<Flight>(updateFlightDto); // AutoMapper kullanarak UpdateFlightDTO nesnesini Flight nesnesine dönüştürdük.
            await _flightCollection.ReplaceOneAsync(flight => flight.FlightId == updateFlightDto.FlightId, values); // ReplaceOneAsync metodu ile belirtilen ID'ye sahip uçuşu güncelledik.
        }
    }
}
