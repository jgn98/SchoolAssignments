namespace HYDAC_Projekt;

public class Guest

{
    public string GuestName { get; set; }

    private string _guestEmail;

    public string GuestEmail
    {
        get => _guestEmail;
        set => _guestEmail = value.ToLower();
    }
    
    public string GuestCompany  { get; set; }
    
    public string GuestContact { get; set; }
    

    //Asks the new guest for several inputs
    public void NewGuest()
    {
        Console.Clear();
        try
        {
            Console.WriteLine("Please enter your name: ");
            GuestName = Console.ReadLine();

            Console.WriteLine("Please enter your company: ");
            GuestCompany = Console.ReadLine();

            Console.WriteLine("Please enter your e-mail address: ");
            GuestEmail = Console.ReadLine();

            Console.WriteLine("Please enter your contact person: ");
            GuestContact = Console.ReadLine();
        
            Console.WriteLine("Please confirm that you have received and read the safety folder:\n" +
                              "1. Yes\n" +
                              "2. No");
            int safety = int.Parse(Console.ReadLine());
            bool folder = false;

            switch (safety)
            {
                case 1:
                    folder = true;
                    break;
                case 2:
                    folder = false;
                    break;
            }
            Console.Clear();
            string message = "";
            if (folder == true)
            {
                message = $"Hello {GuestName}, please proceed to the waiting area. Your contact will be with you shortly\n";
                Console.WriteLine(message);     
            }
            else if (folder == false)
            {
                message =
                    $"Hello {GuestName}, please ask front desk for a safety folder, and proceed to the waiting area. Your contact will be with you shortly \n";
                Console.WriteLine(message);
                folder = true;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    //Asks the guest for their email and contact person if they have been here before, so they don't have to input everything again
    public void PreviousGuest(Log gCheckIn)
    {
        Console.Clear();
        Console.WriteLine("Please enter your email address: ");
        GuestEmail = Console.ReadLine();
        Console.WriteLine("Please enter your contact person: ");
        GuestContact = Console.ReadLine();
        Console.Clear();
    }
    
    //Returns assigned values to the log file when called
    public string LogInfo()
    {
        string message = ($"{GuestName},{GuestCompany},{GuestEmail},{GuestContact}");
        return message;
    }    
}