using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HurtigBiludlejning.Models;

namespace HurtigBiludlejning.ViewModels
{
    public class BookingViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan PickUpTime { get; set; }
        public string Car { get; set; }
        public ObservableCollection<Booking> Bookings { get; set; }

        public BookingViewModel()
        {
            Bookings = new ObservableCollection<Booking>
            {
                new Booking(
                    "Jeppe",
                    "Vej 1",
                    "88888888",
                    "Email@Email.dk",
                    "DK22222",
                    new DateTime(2025, 1, 24),
                    new DateTime(2025, 5, 5),
                    new TimeSpan(5, 5, 5),
                    "Honda Civic"
                ),
                new Booking(
                    "Bo",
                    "Vej 2",
                    "12345678",
                    "Mail@Mail.com",
                    "DK12345",
                    new DateTime(2025, 1, 24),
                    new DateTime(2025, 5, 5),
                    new TimeSpan(5, 5, 5),
                    "VW Up")
            }; ;
        }
    }
}
