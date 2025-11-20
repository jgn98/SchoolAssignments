namespace Tek_12_GlobalVariable;

class Program
{
    static void Main(string[] args)
    {
        Thread thread1 = new Thread(() => 
        { 
            int result = Globals.Sum();
            Interlocked.Add(ref Globals.mainSum, result); 
        });
        
        
        
        Thread thread2 = new Thread(() => 
        { 
            int result = Globals.Sum();
            Interlocked.Add(ref Globals.mainSum, result); 
        });
        
        
        
        Thread thread3 = new Thread(() => 
        { 
            int result = Globals.Sum();
            Interlocked.Add(ref Globals.mainSum, result); 
        });
        
        thread1.Start();
        thread2.Start();
        thread3.Start();
        
        thread1.Join();
        thread2.Join(); 
        thread3.Join(); 
        
        Console.WriteLine($"MainSum: {Globals.mainSum}");
        
        
        
        
        
    }
}