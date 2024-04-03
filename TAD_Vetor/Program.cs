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
        capacity = 8;
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
        if (r >= 0 && r <= Size()) //Avaliable to insert
        {
            if (Size() == capacity) IncreaseCapacity();
            if (r == Size()) //Insert in the last position on Vetor
            {
                array[r] = o;
            }
            else
            {
                
            }
            size++;
        }
        else throw new Exception("Indice Invalido.");
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
}