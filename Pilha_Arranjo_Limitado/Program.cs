
/*
Pilha baseada em arranjo com capacidade limitada
*/
using System;
class Program
{
    public static void Main(string[] args)
    {
        // Testes
        Pilha<int> p1 = new Pilha<int>(4);
        Console.WriteLine(p1);
        p1.Push(4);
        p1.Push(3);
        p1.Push(2);
        p1.Push(1);
        Console.WriteLine(p1);
        Console.WriteLine(p1.Pop());
        Console.WriteLine(p1);

        Pilha<string> p2 = new Pilha<string>(4);
        Console.WriteLine(p2);
        p2.Push("oi");
        p2.Push("joao");
        p2.Push("maria");
        p2.Push("renato");
        Console.WriteLine(p2);
        Console.WriteLine(p2.Pop());
        Console.WriteLine(p2);
    }
}
class PilhaCheiaException : Exception
{
    public PilhaCheiaException() : base("A pilha está cheia.") {}
}
class PilhaVaziaException : Exception
{
    public PilhaVaziaException() : base("A pilha está vazia.") {}
}

class Pilha<T>
{
    private int topo = -1;
    private int capacidade;
    private T[] arranjo;
    public Pilha(int capacidade)
    {
        this.capacidade = capacidade;
        arranjo = new T[capacidade];
    }
    public int Size()
    {
        return topo + 1;
    }
    public bool IsEmpty()
    {
        if (topo > -1) return false;
        return true;
    }
    public T Top()
    {
        if (IsEmpty()) throw new PilhaVaziaException();
        return arranjo[topo];
    }
    public void Push(T element)
    {
        if (Size() == capacidade) throw new PilhaCheiaException();
        arranjo[++topo] = element;
    }
    public T Pop()
    {
        if (IsEmpty()) throw new PilhaVaziaException();
        return arranjo[topo--];
    }
    // Método adicional
    public override string ToString()
    {
        string s = "[";
        if (Size() > 0) s += arranjo[0].ToString();
        if (Size() > 1)
        {
            for (int i = 1; i < Size(); i++)
            {
                s += ", " + arranjo[i].ToString();
            }
        }
        s += "]";
        return s;
    }
}