namespace Biludlejning;

public class Booking
{
    private string name;
    private string address;
    private string phone;
    private string email;
    private string licenseNumber;
    private DateTime startDate;
    private DateTime endDate;
    private TimeSpan pickUpTime;
    private string car;

    public Booking(string name, string address, string phone, string email, string licenseNumber, DateTime startDate,
        DateTime endDate, TimeSpan pickUpTime, string car)
    {
        this.name = name;
        this.address = address;
        this.phone = phone;
        this.email = email;
        this.licenseNumber = licenseNumber;
        this.startDate= startDate.Date;
        this.endDate = endDate.Date;
        this.pickUpTime = pickUpTime;
        this.car = car;
    }

    public override string ToString()
    {
        // Format the dates and time for display
        string formattedStartDate = startDate.ToString("dd:MM:yyyy");
        string formattedEndDate = endDate.ToString("dd:MM:yyyy");
        string formattedPickUpTime = pickUpTime.ToString(@"hh\:mm"); // 10:00 format

        return ($"{name}, {address}, {phone}, {email}, {licenseNumber}, {formattedStartDate}, {formattedEndDate}, {formattedPickUpTime} ,{car}");
    }
}