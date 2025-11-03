using Tek10_KomprimitereTal;

bool hold = true;
uint number = 0;


while (hold){
    Console.WriteLine("Welcome to the Prime Number Checker");
    Console.WriteLine("--------------------------------");
    Console.WriteLine("Enter a number: ");
    number = Convert.ToUInt32(Console.ReadLine());
    if (PrimeNumber.IsPrime(number))
    {
        Console.WriteLine("The number is prime");
    }
    else
    {
        Console.WriteLine("The number is not prime");
    }
    Console.WriteLine("--------------------------------");
    Console.WriteLine("Prime factors: ");
    foreach (var primeFactor in PrimeFactor.GetPrimeFactors(number))
        Console.WriteLine(primeFactor);
    Console.WriteLine("--------------------------------");
    Console.WriteLine("Do you want to continue? (y/n)");
    string answer = Console.ReadLine();
    if (answer == "n") hold = false;
    Console.Clear();

}