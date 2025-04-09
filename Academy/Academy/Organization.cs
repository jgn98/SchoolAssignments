namespace Academy;

public abstract class Organization
{
    public string Name { get; }
    
    public  string Address { get; set; }

    public Organization(string name)
    {
        Name = name;
    }

    
}