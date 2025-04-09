namespace ObservablePattern;

public class ConcreteObserver : Observer
{
    private ConcreteSubject subject;
    private int state = 0;

    public int State
    {
        get
        {
            return state;
        }
        set
        {
            state = value;
        }
    }

    public ConcreteObserver(ConcreteSubject subject)
    {
        this.subject = subject;
    }

    public override void Update()
    {
        State = subject.State;
    }
    
}