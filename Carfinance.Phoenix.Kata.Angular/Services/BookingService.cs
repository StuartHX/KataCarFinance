using Carfinance.Phoenix.Kata.Angular.Models;
using Carfinance.Phoenix.Kata.Angular.Services.Interfaces;
using System.Collections.Generic;

namespace Carfinance.Phoenix.Kata.Angular.Services
{
    public class BookingService : IBookingService
    {
        private static IList<Booking> bookings;

        public BookingService() : this(new DataService())
        {
        }

        public BookingService(IDataService dataService)
        {
            bookings = dataService.Initialize();
        }

        public IList<Booking> GetAllBookings()
        {
            return bookings;
        }

        public void CreateBooking(Booking booking)
        {
        }
    }
}