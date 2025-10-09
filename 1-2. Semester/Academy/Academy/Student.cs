namespace Academy;

public class Student : Person
{
    private Academy subject;
    public string Message { get; set; }
    public string Name { get; }

    public Student(Academy subject, string name) : base(name)
    {
        this.subject = subject;
        Name = name;
    }

    public void Update()
    {
        Message = subject.Message;
        Console.WriteLine($"Studerende {Name} modtog nyheden {Message} fra akademiet {subject.Name}, {subject.Adress}");
    }
}