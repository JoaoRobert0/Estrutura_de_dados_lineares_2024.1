using System;

class Program
{
    static void Main()
    {
        Vetor v = new Vetor();
        v.InsertAtRank(0,10);
        v.InsertAtRank(1, 5);
        v.InsertAtRank(2, 7);
        Console.WriteLine(v);
    }
}

class Vetor
{
    private int size;
    private Node head;
    private Node tail;
    public Vetor()
    {
        head = tail;
        tail = head;
        size = 0;
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
            // else if (r <= Size()/2)
            // {
            // }
            // else if (r > Size()/2)
            // {
            // }
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