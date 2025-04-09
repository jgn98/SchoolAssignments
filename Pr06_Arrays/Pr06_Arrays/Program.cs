namespace Pr06_Arrays;

class Program
{
    static void Main(string[] args)
    {
        /*Console.WriteLine("Input age of every team member: ");
        int age1 = int.Parse(Console.ReadLine());
        int age2 = int.Parse(Console.ReadLine());
        int age3 = int.Parse(Console.ReadLine());
        int age4 = int.Parse(Console.ReadLine());
        int age5 = int.Parse(Console.ReadLine());
        int age6 = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine($"The following age has been inputted:\n" +
                          $"{age1}\n" +
                          $"{age2}\n" +
                          $"{age3}\n" +
                          $"{age4}\n" +
                          $"{age5}\n" +
                          $"{age6}\n");
        
        int AvgAge = (age1 + age2 + age3 + age4 + age5 + age6) / 6;
        
        Console.WriteLine($"The average age in your team is {AvgAge}");*/
        
        //Næste opgave, lav samme funktion men med arrays og loops

        bool hold = true;
        do
        {
            Console.Write("Input amount of team members: ");
            
            try
            {
                int arrlength = int.Parse(Console.ReadLine());

                double[] age = new double[arrlength];

                Console.WriteLine("Input age of every team member: ");

                for (int i = 0; i < age.Length; i++)
                {
                    age[i] = double.Parse(Console.ReadLine());
                }

                Console.Clear();

                foreach (double i in age)
                {
                    Console.WriteLine($"The following age was inputted: {i} ");
                }

                double avg = age.Average();
                Console.WriteLine($"The average age of team members is: {avg} ");

                Console.Write("Which age would you like to search for in array?: ");
                int search = int.Parse(Console.ReadLine());

                int index = Array.IndexOf(age, search);
                    if (index >= 0)
                    {
                        Console.WriteLine($"The value {search} was found at {index}");
                    }
                    else
                    {
                        Console.WriteLine($"The value {search} was not found in the array");
                    }
                hold = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        } while (hold == true);
    }
}