using Tek10_KomprimitereTal;

bool running = true;
uint number = 0;


while (running){
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
    Console.WriteLine("Do you want to test another number? (y/n)");
    string answer = Console.ReadLine();
    if (answer == "n") running = false;
    Console.Clear();

}