using System.Security.Cryptography;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.IO;

namespace HYDAC_Projekt;

public class Log
{
    //File path for the log file
    private static readonly string CheckInPath = Path.GetFullPath(@"HydacCheckIn.txt");
    private readonly string _checkIn = CheckInPath;
    private static readonly string CheckOutPath = Path.GetFullPath(@"HydacCheckOut.txt");
    private readonly string _checkOut = CheckOutPath;

    //Keeps track of people on the premises
    private static int _peopleCount;


    public void GuestCheckIn(Guest guestCheckIn)
    {
        
        try
        {
            //System reads the current time and date
            string time = DateTime.Now.ToString();
            //Adds to PeopleCount
            _peopleCount++;
            //Writes guest check-in info to the log file
            using (StreamWriter writer = new StreamWriter(_checkIn, true))
            {
                writer.WriteLine($"{guestCheckIn.LogInfo()}, {time}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public void EmployeeCheckIn(Employee employeeCheckIn)
    {
        try
        {
            //System reads the current time and date
            string time = DateTime.Now.ToString();
            //Adds to PeopleCount
            _peopleCount++;
            //Writes employee check-in info to the log file
        
            using (StreamWriter writer = new StreamWriter(_checkIn, true))
            {
                writer.WriteLine($"{employeeCheckIn.LogInfo()}, {time}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    //Returns and prints the number of people that are left in the building.
    public void PeopleCheckedIn()
    {
        Console.Clear();
        if (_peopleCount <= 0)
        {

            Console.WriteLine("Congratulations! You have the place to yourself. Have a great day!");
        }
        else
        { 
            Console.WriteLine($"The number of people on the premises is: {_peopleCount}\n");
        } 
    }


    

    public void PreviousGuestCheckIn(Guest guestCheckIn)
    {
        try
        {
            foreach (string line in File.ReadLines(_checkIn))
            {
            
                // Regular expression to ensure exact match of the email address
            
                if (Regex.IsMatch(line, @"\b" + Regex.Escape(guestCheckIn.GuestEmail) + @"\b"))
                {
                    string[] parts = Regex.Split(line, ",");
                    // If the line contains the email, output the line
                    guestCheckIn.GuestName = parts[0];
                    guestCheckIn.GuestCompany = parts[1];
                }
            }
            Console.WriteLine($"Hello {guestCheckIn.GuestName}, please proceed to the waiting area. Your contact will be with you shortly\n ");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
    
    public void GuestCheckOut(Guest guestCheckOut)
    {
        try
        {
            guestCheckOut.GuestEmail = Console.ReadLine();
            
            foreach (string line in File.ReadLines(_checkIn))
            {
            
                // Regular expression to ensure exact match of the email address
            
                if (Regex.IsMatch(line, @"\b" + Regex.Escape(guestCheckOut.GuestEmail) + @"\b"))
                {
                    string[] parts = Regex.Split(line, ",");
                    // If the line contains the email, output the line
                    guestCheckOut.GuestName = parts[0];
                    guestCheckOut.GuestCompany = parts[1];
                    guestCheckOut.GuestEmail = parts[2];
                    guestCheckOut.GuestContact = parts[3];
                }
            }

            //System reads the current time and date
            string time = DateTime.Now.ToString();
            
            _peopleCount--;
            //Writes guest check-out info to the log file
            using (StreamWriter writer = new StreamWriter(_checkOut, true))
            {
                writer.WriteLine($"{guestCheckOut.LogInfo()}, {time}");
            }
            Console.Clear();
            Console.WriteLine($"{guestCheckOut.GuestName} has successfully been checked out\n ");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public void EmployeeCheckOut(Employee employeeCheckOut)
    {
        try
        {
            employeeCheckOut.EmployeeEmail = Console.ReadLine();
            
            foreach (string line in File.ReadLines(_checkIn))
            {
            
                // Regular expression to ensure exact match of the email address
            
                if (Regex.IsMatch(line, @"\b" + Regex.Escape(employeeCheckOut.EmployeeEmail) + @"\b"))
                {
                    string[] parts = Regex.Split(line, ",");
                    // If the line contains the email, output the line
                    employeeCheckOut.EmployeeName = parts[0];
                    employeeCheckOut.EmployeeEmail = parts[1];
                    employeeCheckOut.EmployeeDepartment = parts[2];
                }
            }

            //System reads the current time and date
            string time = DateTime.Now.ToString();
            
            _peopleCount--;
            //Writes guest check-out info to the log file
            using (StreamWriter writer = new StreamWriter(_checkOut, true))
            {
                writer.WriteLine($"{employeeCheckOut.LogInfo()}, {time}");
            }
            Console.Clear();
            Console.WriteLine($"{employeeCheckOut.EmployeeName} has successfully been checked out\n ");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
