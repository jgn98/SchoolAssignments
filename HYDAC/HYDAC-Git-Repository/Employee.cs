namespace HYDAC_Projekt;

public class Employee
{
    public string EmployeeName { get; set; }

    private string _employeeEmail;

    public string EmployeeEmail
    {
        get => _employeeEmail;
        set => _employeeEmail = value.ToLower();
    }
    public string EmployeeDepartment { get; set; }
    
    //Asks the employee for their email
    public void EmployeeInfo()
    {
        Console.WriteLine("Please enter your email address: ");
        try
        {
            EmployeeEmail = Console.ReadLine();
        
            switch (EmployeeEmail)
            {
                case "jh@hydac.com":
                    EmployeeName = "Jens Haugaard";
                    EmployeeDepartment = "CEO";
                    EmployeeEmail = "jh@hydac.com";
                    break;
            
                case "sm@hydac.com":
                    EmployeeName = "Søren Madsen";
                    EmployeeDepartment = "Front Office";
                    EmployeeEmail = "sm@hydac.com";
                    break;
                case "lp@hydac.com":
                    EmployeeName = "Lasse Petersen";
                    EmployeeDepartment = "External Sales";
                    EmployeeEmail = "lp@hydac.com";
                    break;

                case "rs@hydac.com":
                    EmployeeName = "Rasmus W. Sørensen";
                    EmployeeDepartment = "R&D";
                    EmployeeEmail = "ra@hydac.com";
                    break;

                case "bn@hydac.com":
                    EmployeeName = "Benjamin Nielsen";
                    EmployeeDepartment = "Planning, Projecting & Support";
                    EmployeeEmail = "bn@hydac.com";
                    break;
            }
        
            Console.Clear();
            Console.WriteLine($"Hello {EmployeeName}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
    
    //Returns the assigned values to the log file when called
    public string LogInfo()
    {
        string message = ($"{EmployeeName},{EmployeeEmail},{EmployeeDepartment}");
        return message;
    }
}