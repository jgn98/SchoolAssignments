namespace Pr04_DoWhile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Spørger om brugerens input til en tekst
            Console.Write("Indsæt tekst: ");
            string str = Console.ReadLine();

            //Laver en int ud fra tekst længden
            int length = str.Length;

            //Laver en count int der starter på 0
            int count = 0;

            //Starter while loop med betingelsen, at count er mindre en tekstlængden
            while (count < length)
            {
                //char laves indenfor brackets, for at variablen skifter med count
                char chr = str[count];

                //Skriver hvad værdi count har, efterfulgt af char variablen som skifter med count
                Console.WriteLine($"{count}: '{chr}'");

                //Lægger +2 til count ved hvert loop
                count += 2;
            }
        }
    }
}
