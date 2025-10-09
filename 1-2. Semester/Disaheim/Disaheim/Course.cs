namespace Disaheim;

public class Course
{
    public string Name;
    public int DurationInMinutes;

    public Course(string name)
    {
        Name = name;
    }

    public Course(string name, int durationInMinutes)
    {
        Name = name;
        DurationInMinutes = durationInMinutes;
    }

    public override string ToString()
    {
        return ($"Name: {Name}, Duration in Minutes: {DurationInMinutes}");
    }
}