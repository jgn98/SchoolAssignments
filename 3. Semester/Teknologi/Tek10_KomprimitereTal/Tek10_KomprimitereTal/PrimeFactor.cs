namespace Tek10_KomprimitereTal;

public static class PrimeFactor
{
    public static List<uint> GetPrimeFactors(uint number)
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
}