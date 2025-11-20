namespace Tek_12_GlobalVariable;

public static class Globals
{
    public static int mainSum = 0;

    public static int Sum()
    {
        int mySum = 0;
        Random rng = new Random(); 
        for (int i = 0; i < 10000; i++)
        {
            Thread.Sleep(1);
            int randomNumber = rng.Next(0,9); 
            mySum += randomNumber;
        }
        Console.WriteLine($"Sum: {mySum}");
        return mySum;
    }
}