namespace Pr03_strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Spørger brugeren om input til en vilkårlig tekststreng
            Console.Write("Indlæs en vilkårlig tekststreng: ");
            string tekst = Console.ReadLine();

            //Laver tekstens længde til en int
            int lenght = tekst.Length;

            //Udskriver tekstens længde til konsollen
            Console.WriteLine($"Tekstens længde er {lenght}");

            //Laver en substring der udskriver de første 5 bogstaver i teksten
            string substring = tekst.Substring(0, 5);

            //Laver substring tekstens længde til en int
            int substringlenght = substring.Length;

            //Udskriver de første 5 karakterer i teksten samt tekstens længde til konsollen
            Console.WriteLine($"De første 5 bogstaver i teksten er {substring} og teksten er {substringlenght} karakterer lang");

            //Spørger brugeren om input til hvilken karakter der søges efter
            Console.Write("Indlæs den karakter der søges efter i teksten: ");

            //Konverterer brugerens input til char
            char x = Convert.ToChar(Console.ReadLine());

            //Finder positionen af den valgte char
            int index = tekst.IndexOf(x);

            //Udskriver en conditional message alt efter om brugerens char blev fundet eller ej
            string message = "";

            if (index > -1)
            {
                message = $"Den indtastede karakter blev fundet i position {index}";
            }
            else
            {
                message = "Den indtastede karakter blev ikke fundet";
            }
            Console.WriteLine(message);


        }
    }
}
