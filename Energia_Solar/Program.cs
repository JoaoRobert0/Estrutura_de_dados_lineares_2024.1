using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> casas = new List<int>(){3, 6, 2, 7, 5};
        List<Pilha> linhas = new List<Pilha>();

        while (casas.Count > 0)
        {
            if (casas.Count == 1)
            {
                // Instanciando uma pilha com a unica casa disponivel
                Pilha pilha = new Pilha();
                pilha.Push(casas[0]);
                
                // Adicionando a uma linha de força
                linhas.Add(pilha);

                // Removendo das casas
                casas.RemoveAt(0);
            }

            // Ainda possui duas ou mais casas disponiveis
            else
            {
                if (casas[0] > casas[1])
                {
                }
                else if (casas[0] < casas[1])
                {
                    Pilha pilha = new Pilha();
                    pilha.Push(casas[1]);

                    for (int i = 2; i < casas.Count < i++)
                    {
                        // Se o atual for menor que o anterior,
                        // entrar na linha de força
                        if (casas[i] < casas[i - 1])
                        {
                            pilha.Push(casas[i]);
                        }
                    }

                    // Linha finalizada
                    linhas.Add(pilha);

                    // Removendo de casas os elementos que foram adicionados na linha
                    // O(n^2) nem um pouco perfomatico
                    // int inseridos = pilha.Size();
                    // while (inseridos > 0)
                    // {
                    //     for (int i = 0; i < pilha.Size(); i++)
                    //     {
                    //         for (int j = casas.Count - 1; j >= 0; j--)
                    //         {
                    //             if (pilha.Top() == casas[j])
                    //         }
                    //     }
                    // }
                }
            }
        }

        int i = 0;
        foreach (Pilha aux in linhas)
        {
            Console.WriteLine($"Linha de força {++i}:");
            aux.Show();
            Console.WriteLine();
        }
        
    }
}

class Pilha
{
    private object[] array;
    private int topo;
    private int capacidade = 1;
    public Pilha()
    {
        array = new object[capacidade];
        topo = -1;
    }
    
    public int Size()
    {
        return topo + 1;
    }

    public bool IsEmpty()
    {
        if (topo == -1) return true;
        return false;
    }

    public object Top()
    {
        if (topo == -1) throw new Exception("Não é possivel visualizar elemnto, pois a pilha está vazia");
        return array[topo];
    }
    
    public void Push(object obj)
    {
        if (topo == capacidade - 1)
        {
            // Estrategia de duplicação
            // Testar as outras estrategias
            capacidade *= 2;
            object[] arrayAux = new object[capacidade];
            
            for (int i = 0; i < topo; i++)
            {
                arrayAux[i] = array[i];
            }

            topo++;
            arrayAux[topo] = obj;
            
            array = arrayAux;
        }
        else
        {
            topo++;
            array[topo] = obj;
        }
    }

    public object Pop()
    {
        if (topo == -1) throw new Exception("Não é possivel remover um elemnto, pois a pilha está vazia");
        topo--;
        return array[topo + 1];
    }
    
    // Metodos auxiliares
    public void Show()
    {
        Console.Write("[");
        for (int i = 0; i <= topo; i++)
        {
            if (i == 0) Console.Write(array[i]);
            else Console.Write($", {array[i]}");
        }
        Console.WriteLine("]");
    }

    public int Capacity()
    {
        return capacidade;
    }

    public void Empty(int capacidade)
    {

        object[] novoArray = new object[capacidade];

        array = novoArray;
        novoArray = null;

        topo = -1;
        this.capacidade = capacidade;
    }

}