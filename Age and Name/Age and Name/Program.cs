namespace Age_and_Name
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Indtast navn: ");
            string name;
            name = Console.ReadLine();

            Console.Write("Indtast alder: ");
            int alder;
            alder = int.Parse(Console.ReadLine());

            if (alder >= 0 && alder <= 9)
            {
                string barn = " og er et barn";
                Console.WriteLine(name + " er " + alder + " år gammel" + barn);
            }
            else if (alder >= 13 && alder <= 19)
            {
                string teenager = " og er en teenager";
                Console.WriteLine(name + " er " + alder + " år gammel" + teenager);
            }
            else if (alder >= 20 && alder <= 25)
            {
                string studerende = " og er studerende";
                Console.WriteLine(name + " er " + alder + " år gammel" + studerende);
            }
            else if (alder >= 26 && alder <= 67)
            {
                string arbejde = " og er i arbejde";
                Console.WriteLine(name + " er " + alder + " år gammel" + arbejde);
            }
            else if (alder > 67)
            {
                string pensionist = " og er en pensionist";
                Console.WriteLine(name + " er " + alder + " år gammel" + pensionist);
            }
        }
    }
}
