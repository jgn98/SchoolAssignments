bool hold = true;
uint number = 0;

while (hold){
    Console.WriteLine("Welcome to the Prime Number Checker");
    Console.WriteLine("--------------------------------");
    Console.WriteLine("Enter a number: ");
    number = Convert.ToUInt32(Console.ReadLine());
    if (IsPrime(number))
    {
        Console.WriteLine("The number is prime");
    }
    else
    {
        Console.WriteLine("The number is not prime");
    }
    Console.WriteLine("--------------------------------");
    Console.WriteLine("Prime factors: ");
    foreach (var primeFactor in GetPrimeFactors(number))
        Console.WriteLine(primeFactor);
    Console.WriteLine("--------------------------------");
    Console.WriteLine("Do you want to continue? (y/n)");
    string answer = Console.ReadLine();
    if (answer == "n") hold = false;
    Console.Clear();

}


bool IsPrime(uint number)
{
    if (number <= 1) return false;
    if (number == 2) return true;
    if (number % 2 == 0) return false;
    
    int sqrt = (int)Math.Sqrt(number);
    for (int i = 3; i <= sqrt; i += 2)
    {
        if (number % i == 0) return false;
    }
    
    return true;
}

static List<uint> GetPrimeFactors(uint number)
{
    var factors = new List<uint>();
    
    if (number <= 1)
        return factors;
    
    // Håndter faktor 2
    while (number % 2 == 0)
    {
        factors.Add(2);
        number /= 2;
    }
    
    // Tjek ulige tal fra 3
    uint divisor = 3;
    while (divisor * divisor <= number)
    {
        while (number % divisor == 0)
        {
            factors.Add(divisor);
            number /= divisor;
        }
        divisor += 2;
    }
    
    // Hvis number > 1, er det selv et primtal
    if (number > 1)
        factors.Add(number);
    
    return factors;
}