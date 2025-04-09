namespace Academy;
public delegate void NotifyHandler();
public class Academy : Organization
{
    public NotifyHandler MessageChanged;
    private string _message;
    public string Name { get; }
    
    public string Adress { get; }
    
    public string Message
    {
        get{return _message;}
        set{_message = value; MessageChanged();}
    }

    public Academy(string name, string adress) : base(name)
    {
        Name = name;
        Adress = adress;
    }
    
    
}