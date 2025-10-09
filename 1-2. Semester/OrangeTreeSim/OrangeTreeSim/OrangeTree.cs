namespace OrangeTreeSim;

public class OrangeTree
{
    private int age;
    private int height;
    private bool treeAlive;
    private int numOranges;
    private int orangesEaten;

    public int Age
    {
        get { return age; }
        set
        {
            if (value > 0)
            {
                age = value;
            }
        }
    }

    public int Height
    {
        get { return height; }
        set { height = value; }
    }

    public bool TreeAlive
    {
        get { return treeAlive; }
        set { treeAlive = value; }
    }

    public int NumOranges
    {
        get { return numOranges; }
    }

    public int OrangesEaten
    {
        get { return orangesEaten; }
    }

    public void OneYearPasses()
    {
        age++;
        if (age == 80)
        {
            treeAlive = false;
            numOranges = 0;
        }
        else if (age < 80)
        {
            height += 2;
            if (age > 1)
            {
                numOranges = 0;
                orangesEaten = 0;
                numOranges = (age-1) * 5;
            }
        }
    }

    public void EatOrange(int count)
    {
        orangesEaten += count; 
        numOranges -= count;
    }
}