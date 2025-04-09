using System.Diagnostics;

namespace HYDAC_Projekt;

class Program
{
    static void Main(string[] args)
    {
        bool menuHold = true;

        do
        {
            //Calling the menu class in order to run the menu methods
            Menu menuStart = new Menu();
            menuStart.MainMenu();
            

            switch (menuStart.Choice)
            {
                case 1:
                    //Calling the log and employee classes in order to run check-in methods from the classes
                    Log eCheckIn = new Log();
                    Employee employeeCheckIn = new Employee();
                    employeeCheckIn.EmployeeInfo();
                    //Running the employee check-in method from log class, using the variable from employee class in order to save the inputted data
                    eCheckIn.EmployeeCheckIn(employeeCheckIn);
                    
                    break;

                case 2:
                    //Calling the log and guest classes in order to run check-in methods from the classes
                    menuStart.GuestMenu();
                    int previousVisit = int.Parse(Console.ReadLine());
                    Log gCheckIn = new Log();
                    Guest guestCheckIn = new Guest();
                    switch (previousVisit)
                    {
                        //Switch cases in order to determine whether the guest has previously filled in all information
                        case 1:
                            guestCheckIn.PreviousGuest(gCheckIn);
                            gCheckIn.PreviousGuestCheckIn(guestCheckIn);
                            //Running the guest check-in method from log class, using the variable from guest class in order to save the inputted data
                            gCheckIn.GuestCheckIn(guestCheckIn);

                            break;
                        case 2:
                            guestCheckIn.NewGuest();
                            //Running the guest check-in method from log class, using the variable from guest class in order to save the inputted data
                            gCheckIn.GuestCheckIn(guestCheckIn);
                            break;
                    }
                    break;

                case 3:
                    //Calls checkout method
                    menuStart.CheckOut();
                    Log logCheckOut = new Log();
                    Guest guestCheckOut = new Guest();
                    Employee employeeCheckOut = new Employee();
                    switch (menuStart.Choice)
                    {
                        case 1:
                            logCheckOut.EmployeeCheckOut(employeeCheckOut);                            
                            break;
                        case 2:
                            logCheckOut.GuestCheckOut(guestCheckOut);
                            break;
                    }
                    
                    break;

                case 4:
                    //Shows how many people are checked in
                    Log peopleInBuilding = new Log();                   
                    peopleInBuilding.PeopleCheckedIn();
                    break;

                case 0:
                    //Stops the menu loop if 0 is inputted within the menu
                    menuStart.ConfirmClose();
                    if (menuStart.Choice == 1)
                    {
                        menuHold = false;
                    }

                    if (menuStart.Choice == 2)
                    {
                        Console.Clear();
                    }
                    break;

                default:
                    menuStart.Error();
                    break;
            }
            
        } while (menuHold == true);
    }
}