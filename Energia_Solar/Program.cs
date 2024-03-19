using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Entradas do enunciado
        // {3, 6, 2, 7, 5}
        // {8, 6, 10, 4, 1, 5, 3}

        // Coleguinha, informe o conjuto na definição de casas
        List<int> casas = new List<int>(){3, 6, 2, 7, 5};
        List<Pilha> linhas = new List<Pilha>();

        // O while irá acabar quando não houver mais casas
        while (casas.Count > 0)
        {
            // Se houver apenas uma casa
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
                Pilha pilha = new Pilha();
                List<int> removerIndicesDasCasas = new List<int>();

                if (casas[0] > casas[1])
                {
                    pilha.Push(casas[0]);
                    pilha.Push(casas[1]);

                    removerIndicesDasCasas.Add(0);
                    removerIndicesDasCasas.Add(1);
                }

                else if (casas[0] < casas[1])
                {
                    pilha.Push(casas[1]);

                    removerIndicesDasCasas.Add(1);
                }

                // Percorrendo até a ultima casa
                for (int i = 2; i < casas.Count; i++)
                {
                    // Se o atual for menor que o anterior, entrar na linha de força
                    if (casas[i] < casas[i - 1])
                    {
                        pilha.Push(casas[i]);
                        removerIndicesDasCasas.Add(i);
                    }
                }

                // Removendo as casas a partir dos indices de *removerIndicesDasCasas*
                for (int i = removerIndicesDasCasas.Count - 1; i >= 0; i--)
                {
                    casas.RemoveAt(removerIndicesDasCasas[i]);
                }

                // Linha finalizada
                linhas.Add(pilha);
            }
        }

        int contador = 0;
        foreach (Pilha aux in linhas)
        {
            Console.WriteLine($"Linha de força {++contador}:");
            aux.Show();
            Console.WriteLine();
        }
    }
}

// Implementação da minha Pilha
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
    
    public int Size() { return topo + 1; }

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
            capacidade *= 2;
            object[] arrayAux = new object[capacidade];
            
            for (int i = 0; i <= topo; i++)
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

        else if (Size() == capacidade * 0.25)
        {
            capacidade /= 2;
            object[] arrayAux = new object[capacidade];

            for (int i = 0; i <= topo; i++)
            {
                arrayAux[i] = array[i];
            }

            array = arrayAux;
        }

        topo--;
        return array[topo + 1];
    }
    
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

    public int Capacity() { return capacidade; }

    public void Empty(int capacidade)
    {
        object[] novoArray = new object[capacidade];

        array = novoArray;
        novoArray = null;

        topo = -1;
        this.capacidade = capacidade;
    }
}