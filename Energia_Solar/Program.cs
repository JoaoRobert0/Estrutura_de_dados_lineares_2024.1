using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // {8,6,10,4,1,5,3}
        // {3, 6, 2, 7, 5}
        // Coleguinha, informe o array na definição das casas
        List<int> casas = new List<int>(){8,6,10,4,1,5,3};
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
                    List<int> removerIndices = new List<int>();
                    removerIndices.Add(0);
                    Pilha pilha = new Pilha();
                    pilha.Push(casas[0]);

                    for (int i = 1; i < casas.Count; i++)
                    {
                        // Se o atual for menor que o anterior,
                        // entrar na linha de força
                        if (casas[i] < casas[i - 1])
                        {
                            pilha.Push(casas[i]);
                            removerIndices.Add(i);
                        }
                    }

                    // Removendo as casas a partir dos indices de *removerIndices*
                    for (int i = removerIndices.Count - 1; i >= 0; i--)
                    {
                        casas.RemoveAt(removerIndices[i]);
                    }

                    // Linha finalizada
                    linhas.Add(pilha);
                }
                else if (casas[0] < casas[1])
                {
                    List<int> removerIndices = new List<int>();
                    removerIndices.Add(1);
                    Pilha pilha = new Pilha();
                    pilha.Push(casas[1]);

                    for (int i = 2; i < casas.Count; i++)
                    {
                        // Se o atual for menor que o anterior,
                        // entrar na linha de força
                        if (casas[i] < casas[i - 1])
                        {
                            pilha.Push(casas[i]);
                            removerIndices.Add(i);
                        }
                    }

                    // Removendo as casas a partir dos indices de *removerIndices*
                    for (int i = removerIndices.Count - 1; i >= 0; i--)
                    {
                        casas.RemoveAt(removerIndices[i]);
                    }

                    // Linha finalizada
                    linhas.Add(pilha);
                }
            }
        }

        int counter = 0;
        foreach (Pilha aux in linhas)
        {
            Console.WriteLine($"Linha de força {++counter}:");
            aux.Show();
            Console.WriteLine();
        }
        
    }
}

class Pilha
{
    private object[] array;
    private int topo;
    private int capacidade = 8;
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