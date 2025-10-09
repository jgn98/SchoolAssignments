using System.Data;

namespace ObservablePattern;

public abstract class Subject
{
    private List<Observer> observers = new List<Observer>();

    public void Attach(Observer o)
    {
        observers.Add(o);
    }

    public void Detach(Observer o)
    {
        observers.Remove(o);
    }

    public void Notify()
    {
        foreach (Observer o in observers)
        {
            o.Update();
        }
    }
}