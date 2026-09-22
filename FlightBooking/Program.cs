using FlightBooking.AgentServices.TravelAgentService;
using FlightBooking.Services.BookingServices;
using FlightBooking.Services.CheckInServices;
using FlightBooking.Services.FlightServices;
using FlightBooking.Services.MachineLearningServices;
using FlightBooking.Services.NoShowServices;
using FlightBooking.Services.OverBookingNoShowServices;
using FlightBooking.Settings;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IFlightService, FlightService>(); // IFlightService arayüzünü ve FlightService sýnýfýný DI konteynerine ekledik.
builder.Services.AddScoped<IBookingService, BookingService>(); // IBookingService arayüzünü ve BookingService sýnýfýný DI konteynerine ekledik.
builder.Services.AddScoped<ICheckInService, CheckInService>(); // ICheckInService arayüzünü ve CheckInService sýnýfýný DI konteynerine ekledik.
builder.Services.AddSingleton<FlightMlService>(); // FlightMlService sýnýfýný DI konteynerine ekledik.
builder.Services.AddSingleton<FlightRegressionService>(); // FlightRegressionService sýnýfýný DI konteynerine ekledik.
builder.Services.AddScoped<MongoFlightDataService>(); // MongoFlightDataService sýnýfýný DI konteynerine ekledik.
builder.Services.AddScoped<NoShowService>(); // NoShowService sýnýfýný DI konteynerine ekledik.
builder.Services.AddScoped<ITravelAgentService,TravelAgentService>(); // TravelAgentService sýnýfýný DI konteynerine ekledik.
builder.Services.AddScoped<OverbookingRecommendationService>(); // OverbookingRecommendationService sýnýfýný DI konteynerine ekledik.
builder.Services.AddScoped<NoShowPredictionService>(); // NoShowPredictionService sýnýfýný DI konteynerine ekledik.
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); // AutoMapper'ý DI konteynerine ekledik ve mevcut assembly'i taradýk.
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettingsKey")); // DatabaseSettingsKey sýnýfýný DI konteynerine ekledik ve appsettings.json dosyasýndaki DatabaseSettings bölümünü bind ettik.
builder.Services.AddScoped<IDatabaseSettings>(sp => {
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value; // IDatabaseSettings arayüzünü DI konteynerine ekledik ve DatabaseSettings sýnýfýný bind ettik.
}); 


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
