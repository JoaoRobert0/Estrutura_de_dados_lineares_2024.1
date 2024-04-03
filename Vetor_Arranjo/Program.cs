using System;

class Program
{
    static void Main()
    {
        Vetor v = new Vetor();
        Console.WriteLine(v);
        v.InsertAtRank(0, 20);
        Console.WriteLine(v);
        v.InsertAtRank(1, 15);
        Console.WriteLine(v);
        v.InsertAtRank(0, 7);
        Console.WriteLine(v);
        // v.InsertAtRank(4, 29); error
        // Console.WriteLine(v);
        v.InsertAtRank(2, 11);
        Console.WriteLine(v);
        v.ReplaceAtRank(0, 99);
        Console.WriteLine(v);
        Console.WriteLine(v.RemoveAtRank(0));
        v.RemoveAtRank(0);
        v.RemoveAtRank(0);
       Console.WriteLine(v);
    }
}

class Vetor
{
    private object[] array;
    private int capacity;
    private int size;
    public Vetor()
    {
        capacity = 1;
        array = new object[capacity];
        size = 0;
    }
    public object ElementAtRank(int r)
    {
        if (r >= 0 && r < Size())
        {
            return array[r];
        }
        else throw new Exception("Index out of range");
        
    }
    public object ReplaceAtRank(int r, object o)
    {
        if (r >= 0 && r < Size())
        {
            object aux = array[r];
            array[r] = o;
            return aux;
        }
        else throw new Exception("Index out of range.");
    }
    public void InsertAtRank(int r, object o)
    {
        if (r >= 0 && r <= Size()) //Limits to insert in Vetor
        {
            if (Size() == capacity) IncreaseCapacity();
            if (r == Size()) //Insert in the last position on Vetor
            {
                array[r] = o;
            }
            else
            {
                for (int i = Size(); i > r; i--)
                {
                    array[i] = array[i - 1];
                }
                array[r] = o;
            }
            size++;
        }
        else throw new Exception("Index out of range.");
    }
    public object RemoveAtRank(int r)
    {
        if (r >= 0 && r < Size())
        {
            object aux = array[r];
            if (r == Size() - 1) array[r] = null;
            else
            {
                for (int i = r; i < Size() - 1; i++)
                {
                    array[i] = array[i + 1];
                }
            }
            size--;
            return aux;
        }
        else throw new Exception("Index out of range.");
    }
    public int Size() { return size; }
    public int Capacity() { return capacity; }
    public bool IsEmpty()
    {
        if (Size() == 0) return true;
        return false;
    }
    public void IncreaseCapacity()
    {
        capacity *= 2;
        object[] newArray = new object[capacity];
        for (int i = 0; i < Size(); i++)
        {
            newArray[i] = array[i];
        }
        array = newArray;
    }
    public override string ToString()
    {
        string s = "[";
        if (Size() > 0) s += array[0].ToString();
        if (Size() > 1)
        {
            for (int i = 1; i < Size(); i++)
            {
                s += ", " + array[i].ToString();
            }
        }
        s += "]";
        return s;
    }
}