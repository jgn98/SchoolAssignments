namespace Biludlejning;

class Program
{
    static void Main(string[] args)
    {
        Car car = new Car('C',"BMW",Fuel.Petrol,Status.Available,"CZ12345");
        
        Console.WriteLine(car);

        Booking booking = new Booking("Bo", "Dalum", "12345678","Testmail","12345678", DateTime.Now, DateTime.Now.AddDays(5), TimeSpan.Parse("10:00"), car.ToString());
        
        Console.WriteLine(booking);
    }
}