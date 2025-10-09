using HurtigBiludlejning.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HurtigBiludlejning.ViewModels
{
    public class CarRepo : INotifyPropertyChanged
    {
        private Car car;
        private List<Car> cars = new List<Car>();

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddCarToList(char id, string model, Fuel fuel, Status status, string plate, int mileage)
        {
            car = new Car(id, model, fuel, status, plate, mileage);
            cars.Add(car);
        }
        public Car? GetCarFromList(string plate)
        {
            car.Plate = plate;
            try
            {
                return cars.FirstOrDefault(car => car.Plate == plate);
            }
            catch
            {
                NullReferenceException e = new NullReferenceException("Car not found");
                return null;
            }
        }
        public void RemoveCarFromList(string plate)
        {
            car.Plate = plate;

            Car selectedCar = GetCarFromList(plate);

            cars.Remove(selectedCar);
        }
        public void UpdateCarInList(char id, string model, Fuel fuel, Status status, string plate, int mileage)
        {
            car.Plate = plate;

            Car selectedCar = GetCarFromList(plate);
            
            cars.Remove(selectedCar);
            AddCarToList(id, model, fuel, status, plate, mileage);
        }
        public void ChangeStatus(string plate, Status status)
        {
            car.Plate = plate;

            Car selectedCar = GetCarFromList(plate);
            char id = selectedCar.Id;
            string model = selectedCar.Model;
            Fuel fuel = selectedCar.Fuel;
            int mileage = selectedCar.Mileage;

            cars.Remove(selectedCar);

            AddCarToList(id, model, fuel, status, plate, mileage);

        }
        public int GetMilage(string plate)
        {
            car.Plate = plate;

            Car selectedCar = GetCarFromList(plate);
            return selectedCar.Mileage;
        }

        public CarRepo () 
        {

        }

    }
}
