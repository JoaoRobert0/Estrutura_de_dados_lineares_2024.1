using System;

class Program
{
    static void Main()
    {

    }
}

class Vetor
{
    private object[] array;
    private int capacity;
    private int size;
    public Vetor()
    {
        capacity = 2;
        array = new object[capacity];
        size = 0;
    }
    public object ElementAtRank(int r)
    {
        
    }
    public object ReplaceAtRank(int r, object o)
    {

    }
    public void InsertAtRank(int r, object o)
    {
        if (r >= capacity) throw new Exception("Indice invalido!");
    }
    public object RemoveAtRank(int r)
    {

    }
    public int Size() { return size; }
    public bool IsEmpty()
    {
        if (Size() == 0) return true;
        return false;
    }
}