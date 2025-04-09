using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HurtigBiludlejning.Models
{
    public class Booking
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan PickUpTime { get; set; }
        public string Car {  get; set; }

        public Booking(string name, string address, string phone, string email, string licenseNumber, DateTime startDate,
            DateTime endDate, TimeSpan pickUpTime, string car)
        {
            Name = name;
            Address = address;
            Phone = phone;
            Email = email;
            LicenseNumber = licenseNumber;
            StartDate = startDate.Date;
            EndDate = endDate.Date;
            PickUpTime = pickUpTime;
            Car = car;
        }


        public override string ToString()
        {
            string formattedStartDate = StartDate.ToString("dd:MM:yyyy");
            string formattedEndDate = EndDate.ToString("dd:MM:yyyy");
            string formattedPickUpTime = PickUpTime.ToString(@"hh\:mm");

            return ($"{Name}, {Address}, {Phone}, {Email}, {LicenseNumber}, {formattedStartDate}, {formattedEndDate}, {formattedPickUpTime} ,{Car}");
        }
    }
}
