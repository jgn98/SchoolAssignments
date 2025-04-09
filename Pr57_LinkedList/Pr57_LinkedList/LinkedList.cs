using System.Text;

namespace Pr57_LinkedList;

public class LinkedList
{
    public Node Head { get; set; }
    
    public int Count { get; set; }

    public LinkedList()
    {
        Head = null;
        Count = 0;
    }

    public void InsertAt(int index, object o)
    {
        if (index < 0 || index > Count)
            throw new IndexOutOfRangeException("Index is out of range");
        
        
        Node newNode = new Node(o);

        if (index == 0)
        {
            newNode.Next = Head;
            Head = newNode;
        }
        else
        {
            Node current = Head;
            for (int i = 0; i < index-1; i++)
            {
                current=current.Next;   
            }
            
            newNode.Next = current.Next;
            current.Next = newNode;
        }
        
        Count++;
    }

    public void DeleteAt(int index)
    {
        if (Head == null)
            throw new InvalidOperationException("The list is empty");
        
        if (index < 0 || index > Count)
            throw new IndexOutOfRangeException("Index is out of range");

        if (index == 0)
        {
            Head = Head.Next;
            Count--;
            return;
        }
        Node current = Head;
        for (int i = 0; i < index; i++)
        {
            current = current.Next;
        }
        
        if (current.Next == null)
            throw new IndexOutOfRangeException("Index is out of range");
        
        current.Next = current.Next.Next;

        Count--;

    }

    public object ItemAt(int index)
    {
        if (Head == null)
            throw new InvalidOperationException("The list is empty");
        
        if (index < 0 || index > Count)
            throw new IndexOutOfRangeException("Index is out of range");
        
        Node current = Head;
        for (int i = 0; i < index; i++)
        {
            current = current.Next;
        }

        return current.Data;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        Node current = Head;
        
        sb.Append(current.Data);
        current = current.Next;

        while (current != null)
        {
            sb.Append("\n");
            sb.Append(current.Data);
            current = current.Next;
        }
        return sb.ToString();
    }
}