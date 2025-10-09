using System.ComponentModel.Design;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //Opretter boolsk værdi til at holde lommeregneren kørende
            bool hold = true;
            
            //Opretter do-while loop, til at holde programmet kørende så længe "hold == true"
            do
            {
                //Udskriver menu til konsollen
                Console.Write("Vælg matematisk operator:\n" +
                    "1. Addition\n" +
                    "2. Multiplikation\n" +
                    "3. Divison\n" +
                    "4. Subtraktion\n" +
                    "5. Modulus\n" +
                    "6. Afslut\n");

                //Læser brugerens input og konverterer til int
                int choice = int.Parse(Console.ReadLine());

                //Starter if, else statement således at switch loopet kun bliver kørt hvis man taster en matematisk funktion i menuen
                if (choice >= 1 && choice <= 5)
                {
                    //Læser brugerens input til regnestykket
                    Console.Clear();
                    Console.Write("Indlæs første tal: ");
                    float x = float.Parse(Console.ReadLine());

                    Console.Write("Indlæs andet tal: ");
                    float y = float.Parse(Console.ReadLine());

                    CalculatorClass calc = new CalculatorClass();

                    //Opretter switch loop til matematiske funktioner
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine(calc.Add(x, y));
                            Console.WriteLine();
                            break;

                        case 2:
                            Console.WriteLine(calc.Multiply(x, y));
                            Console.WriteLine();
                            break;

                        case 3:
                            Console.WriteLine(calc.Divide(x, y));
                            Console.WriteLine();
                            break;

                        case 4:
                            Console.WriteLine(calc.Subtract(x, y));
                            Console.WriteLine();
                            break;

                        case 5:
                            Console.WriteLine(calc.Mod(x, y));
                            Console.WriteLine();
                            break;
                    }
                }
                //Afslutter programmet hvis man trykker "6"
                else if (choice == 6)
                {
                    hold = false;
                }
                //Dummy proof, hvis man trykker andet end et tal i menuen
                else
                {
                    Console.WriteLine("Forkert input, prøv igen");
                }
            }while (hold == true);
        }
    }
}
