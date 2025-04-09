namespace Biludlejning;

public class Car : Category
{
    private string _model;
    private Fuel _fuel;
    private Status _status;
    private string _plate;

    public Car(char id, string model, Fuel fuel, Status status, string plate) : base(id)
    {
        _model = model;
        _fuel = fuel;
        _status = status;
        _plate = plate;
        
    }

    public override string ToString()
    {
        return ($"Car is ID: {_id} Description: {_description} Model: {_model}, fuel: {_fuel}, status: {_status}, plate: {_plate}");
    }
}