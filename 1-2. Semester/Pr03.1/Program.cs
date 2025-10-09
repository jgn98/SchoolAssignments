namespace Pr03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Spørger om input fra brugeren til højde og bredde, og konverterer til double
            Console.Write("Indtast højde på rektangel: ");
            double Height = double.Parse(Console.ReadLine());

            Console.Write("Indtast bredde på rektangel: ");
            double Width = double.Parse(Console.ReadLine());

            //Beregner arealet ved hjælp af højde og bredde
            double Area = Height * Width;

            //Udskriver rektanglets areal til konsollen
            Console.WriteLine($"Rektanglets areal er {Area}");


            //Spørger om input fra brugeren til start og slutpunkter for x og y koordinaterne og konverterer til double
            Console.Write("Indlæs startpunktets x koordinat x1: ");
            double x1 = double.Parse(Console.ReadLine());

            Console.Write("Indlæs startpunktets y koordinat y1: ");
            double y1 = double.Parse(Console.ReadLine());

            Console.Write("Indlæs slutpunktets x koordinat x2: ");
            double x2 = double.Parse(Console.ReadLine());

            Console.Write("Indlæs slutpunktets y koordinat y2: ");
            double y2 = double.Parse(Console.ReadLine());

            //Beregner linjestykkets hældning
            double h = (y2 - y1) / (x2 - x1);

            //Udskriver linjestykkets hældning til konsollen
            Console.WriteLine($"Hældningen for linjestykket er {h}");
        }
    }
}
