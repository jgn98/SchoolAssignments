namespace Pr22_Øvelse_2._1;

class Program
{
    static void Main(string[] args)
    {
        string path = Path.GetFullPath(@"TestFil.txt");
        string message = "Hello World";

        StreamWriter? sw = null;
        try
        {
            sw = new StreamWriter(path);
                sw.WriteLine(message);
        }
        finally
        {
            sw?.Close();
        }
        
        StreamReader? sr = null;

        try
        {
            sr = new StreamReader(path);
            string? lines = sr.ReadLine();
            
            Console.WriteLine(lines);
        }
        finally
        {
            sr?.Close();
        }
    }
}