using HurtigBiludlejning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HurtigBiludlejning.ViewModels
{
    public class BookingRepo
    {
        private Booking booking;
        private List<Booking> bookings = new List<Booking>();

        public void AddBookingToList(string name, string address, string phone, string email, string licenseNumber, DateTime startDate, DateTime endDate, TimeSpan pickUpTime, string car)
        {
            booking = new Booking(name, address, phone, email, licenseNumber, startDate, endDate, pickUpTime, car);
            bookings.Add(booking);
        }
        public Booking? GetBookingFromList(string phone)
        {
            booking.Phone = phone;
            try
            {
                return bookings.FirstOrDefault(booking => booking.Phone == phone);
            }
            catch
            {
                NullReferenceException e = new NullReferenceException("Booking not found");
                return null;
            }
        }

        public void DeleteBookingFromList(string phone)
        {
            booking.Phone = phone;
            Booking selectedBooking = GetBookingFromList(phone);
            bookings.Remove(selectedBooking);
        }
        public void UpdateBookingInList(string phone, DateTime startDate, DateTime endDate, TimeSpan pickUpTime)
        {
            booking.Phone = phone;
            Booking selectedBooking = GetBookingFromList(phone);
            string name = selectedBooking.Name;
            string address = selectedBooking.Address;
            string email = selectedBooking.Email;
            string licenseNumber = selectedBooking.LicenseNumber;
            string car = selectedBooking.Car;
            bookings.Remove(selectedBooking);
            AddBookingToList(name, address, phone, email, licenseNumber, startDate, endDate, pickUpTime, car);
        }

    }
}
