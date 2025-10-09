using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HurtigBiludlejning.Models
{
    public class Car : Category
    {
        public char Id {  get; set; }
        public string Model {  get; set; }
        public Fuel Fuel { get; set; }
        public Status Status { get; set; }
        public string Plate { get; set; }
        public int Mileage { get; set; }

        public Car(char id, string model, Fuel fuel, Status status, string plate, int milage) : base(id)
        {
            Id = id;
            Model = model;
            Fuel = fuel;
            Status = status;
            Plate = plate;
            Mileage = milage;

        }

        public override string ToString()
        {
            return ($"Category: {_id} Model: {Model}, Fuel: {Fuel}, Status: {Status}, Plate: {Plate} Milage: {Mileage}");
        }
    }
}
