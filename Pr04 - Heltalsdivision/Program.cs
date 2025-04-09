namespace Pr04___Heltalsdivision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Spørger brugeren om input til første og andet tal og konverterer til int
            Console.Write("Indtast første heltal: ");
            int x = int.Parse(Console.ReadLine());

            Console.Write("Indtast andet heltal: ");
            int y = int.Parse(Console.ReadLine());

            //Divide laver en almindelig divison mellem 2 heltal
            double divide = x / y;

            //Modulus beregner hvor mange gange y går op i x, og returnerer det resterende
            //eks. 11%5 returnerer 1, da der er 1 tilbage når 5 er gået op i 11 2 gange
            double modulus = x % y;

            //Udskriver de to resultater til konsollen
            Console.WriteLine($"Divide = {divide}");
            Console.WriteLine($"Modulus = {modulus}");
        }
    }
}
