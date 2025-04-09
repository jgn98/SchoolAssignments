namespace ObservablePattern;

public class ConcreteSubject : Subject
{
    private int state;

    public int State
    {
        get
        {
            return state;
        }
        set
        {
            
            state = value;
            Notify();
        }
    }
}