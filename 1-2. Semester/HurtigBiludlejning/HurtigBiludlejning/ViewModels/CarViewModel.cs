using HurtigBiludlejning.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HurtigBiludlejning.ViewModels
{
    internal class CarViewModel
    {
        CarRepo carRepo = new CarRepo();
        private char id;
        private string model;
        private Fuel fuel;
        private Status status;
        private string plate;
        private int mileage;


        public ObservableCollection<Car> Cars { get; set; }

        public CarViewModel()
        {
            Cars = new ObservableCollection<Car>
            {
                new Car(
                    'a',
                    "Audi",
                    Fuel.Petrol,
                    Status.Available,
                    "AB12345",
                    165655
                    )

            }; 

        }



public void AddNewCar(CarViewModel carViewModel)
        {
            carRepo.AddCarToList(id, model, fuel, status, plate, mileage);
        }
        public void DeleteCar(CarViewModel carViewModel)
        {
            carRepo.RemoveCarFromList(plate);
        }
        public void UpdateCar(CarViewModel carViewModel)
        {
            carRepo.UpdateCarInList(id,model,fuel,status,plate,mileage);
        }
        public void SelectedCar(CarViewModel carViewModel)
        {
            carRepo.GetCarFromList(plate);
        }
        
    }
}
