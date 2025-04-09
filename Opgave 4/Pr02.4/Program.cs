using System.Reflection.Metadata.Ecma335;

namespace Pr02._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Udskriver en menu til konsollen
            Console.WriteLine(
                "Min fantatiske menu: \n\n" +
                "1. Få en ny bil \n" +
                "2. Få en hund \n" +
                "3. Få et hus \n" +
                "4. Få svaret på livet, universet og alting \n" +
                "5. Afslut \n\n" +
                "Tryk menu punkt 1, 2, 3, 4 eller 5");

            //Opretter en boolsk variabel til at holde switch loopet kørende
            bool hold = true;

            //Starter et while loop med betingelsen at "hold" == true, som bliver ved med at genstarte switch loopet indtil "hold" == false
            while (hold == true)
            {

                //Modtager brugerens input og konverterer til int
                int choice = int.Parse(Console.ReadLine());

                //Conditional message afhægengig af hvad brugeren indtaster
                string message = "";

                switch (choice)
                {
                    case 1:
                        message = "Du har fået en ny bil";
                        hold = false;
                        break;

                    case 2:
                        message = "Du har fået en ny hund";
                        hold = false;
                        break;

                    case 3:
                        message = "Du har fået et nyt hus";
                        hold = false;
                        break;

                    case 4:
                        message = "Der er ingen mening med livet";
                        hold = false;
                        break;

                    case 5:
                        message = "Menu afsluttet";
                        hold = false;
                        break;

                    default:
                        message = "Vælg venligt et af de 4 tal i menuen";
                        break;
                }
                //Udskriver brugerens valg samt conditional message, hvor {0} angiver første ting efter kommaet, og {1} angiver første ting efter andet komma
                Console.WriteLine("Punkt {0} er valgt: {1}", choice, message);
            }
        }
    }
}
