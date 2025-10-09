namespace Pr57_LinkedList;

public class Node
{
    public object Data { get; set; }
    public Node Next { get; set; }

    public Node(object data)
    {
        Data = data;
        Next = null;
    }

    public override string ToString()
    {
        return Data.ToString();
    }
}