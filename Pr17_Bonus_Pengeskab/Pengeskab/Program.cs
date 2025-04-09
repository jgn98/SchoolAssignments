namespace Pengeskab;

class Program
{
    static void Main(string[] args)
    {
        bool hold = true;
        State state = State.Locked;

        while (hold == true)
        {
            Console.WriteLine($"The safe is {state}. What do you want to do?\n\n" +
                              $"1. Open\n" +
                              $"2. Close\n" +
                              $"3. Lock\n" +
                              $"4. Unlock");
            ConsoleKeyInfo Choice = Console.ReadKey(true);
            if (char.IsDigit(Choice.KeyChar))
            {
                int choice = int.Parse(Choice.KeyChar.ToString());

                switch (choice)
                {
                    case 1:
                        if (state == State.Unlocked)
                        {
                            state = State.Open;
                            Console.Clear();
                            Console.WriteLine($"The safe is {state}.");
                        }
                        else if (state == State.Open)
                        {
                            Console.Clear();
                            Console.WriteLine("The safe is already open.");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("The safe is locked.");
                        }

                        break;
                    case 2:
                        if (state == State.Open)
                        {
                            state = State.Closed;
                            Console.Clear();
                            Console.WriteLine($"The safe is {state}.");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("The safe is already closed.");
                        }

                        break;
                    case 3:
                        if (state == State.Closed)
                        {
                            state = State.Locked;
                            Console.Clear();
                            Console.WriteLine($"The safe is {state}.");
                        }
                        else if (state == State.Open)
                        {
                            Console.Clear();
                            Console.WriteLine("You can't lock the safe when it is open.");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("The safe is already locked.");
                        }

                        break;
                    case 4:
                        if (state == State.Locked)
                        {
                            state = State.Unlocked;
                            Console.Clear();
                            Console.WriteLine($"The safe is {state}.");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("The safe is already unlocked.");
                        }

                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input.");
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid choice."); 
            }
        }
    }
}