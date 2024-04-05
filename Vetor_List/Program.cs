using System;

class Program
{
    static void Main()
    {
        Vetor v = new Vetor();
        v.InsertAtRank(0,10);
        v.InsertAtRank(1,5);
        v.InsertAtRank(2,7);
        v.InsertAtRank(3,22);
        v.InsertAtRank(4, 11);
        Console.WriteLine(v);
        Console.WriteLine(v.head.GetElement());
        Console.WriteLine(v.tail.GetElement());
    }
}

class Vetor
{
    private int size;
    public Node head;
    public Node tail;
    public Vetor()
    {
        head = tail;
        tail = head;
        size = 0;
    }
    public object ElementAtRank(int r)
    {
        if (r >= 0 && r < Size())
        {
            if (r <= Size()/2)
            {
                Node aux = head;
                for (int i = 0; i < r; i++)
                {
                    aux = aux.GetNext();
                }
                return aux.GetElement();
            }
            else
            {
                Node aux = tail;
                for (int i = Size() - 1; i > r; i--)
                {
                    aux = aux.GetPrevious();
                }
                return aux.GetElement();
            }
        }
        else throw new Exception("Index out of range.");
    }
    public void InsertAtRank(int r, object o)
    {
        if (r >= 0 && r <= Size())
        {
            Node newNode = new Node(null, o, null);
            if (IsEmpty()) // O(1)
            {
                head = newNode;
                tail = newNode;
            }
            else if (r == 0) // Insert at beginning O(1)
            {
                head.SetPrevious(newNode);
                newNode.SetNext(head);
                head = newNode;
            }
            else if (r == Size()) //Insert at ending O(1)
            {
                tail.SetNext(newNode);
                newNode.SetPrevious(tail);
                tail = newNode;
            }
            else if (r <= Size()/2)
            {
                Node aux1 = head;
                for (int i = 0; i < r; i++)
                {
                    aux1 = aux1.GetNext(); //Aux stop at index "r"
                }
                Node aux2 = aux1.GetPrevious();
                
                aux1.SetPrevious(newNode);
                aux2.SetNext(newNode);

                newNode.SetNext(aux1);
                newNode.SetPrevious(aux2);
            }
            else //(r > Size()/2)
            {
                Node aux1 = tail;
                for (int i = Size(); i > r; i--)
                {
                    aux1 = aux1.GetPrevious();
                }
                Node aux2 = aux1.GetNext();
                
                aux1.SetNext(newNode);
                aux2.SetPrevious(newNode);

                newNode.SetPrevious(aux1);
                newNode.SetNext(aux2);
            }
            size++;
        }
        else throw new Exception("Index out of range.");
    }
    public bool IsEmpty()
    {
        if (Size() == 0) return true;
        return false;
    }
    public int Size() { return size; }
    public override string ToString()
    {
        Node aux = head;
        string s = "[";
        if (Size() > 0) s += aux.GetElement().ToString();
        if (Size() > 1)
        {
            for (int i = 1; i < Size(); i++)
            {
                aux = aux.GetNext();
                s += ", " + aux.GetElement().ToString();
            }
        }
        s += "]";
        return s;
    }
}

class Node
{
    private Node prev;
    private Node next;
    private object element;
    public Node(Node p, object o, Node n)
    {
        prev = p;
        element = o;
        next = n;
    }
    public void SetElement(object o) { element = o; }
    public void SetPrevious(Node newNode) { prev = newNode; }
    public void SetNext(Node newNode) { next = newNode; }
    public object GetElement() { return element; }
    public Node GetPrevious() { return prev; }
    public Node GetNext() { return next; }
}