﻿using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        // Instanciando a pilha e definindo tamanho inicial
        PilhaRubroNegra prb = new PilhaRubroNegra(4);

        int comando = 0;
        while (comando != 99)
        {
            // Interface do usuario
            Console.WriteLine(
                "------Menu-----\n" +
                "1-Listar\n" +
                "2-Push Vermelho\n" +
                "3-Pop Vermelho\n" +
                "4-Push Preto\n" +
                "5-Pop Preto");

            Console.Write("Selecione o valor da operação desejada: ");
            comando = int.Parse(Console.ReadLine());

            Thread.Sleep(1000);
            Console.Clear();

            switch (comando)
            {
                // Listar
                case 1:
                    Console.WriteLine($"Capacidade: {prb.GetCapacity()}");
                    Console.WriteLine($"Tamanho pilha vermelha: {prb.GetSizeVermelho()}");
                    Console.WriteLine($"Tamanho pilha preta: {prb.GetSizePreto()}");

                    foreach (object elemento in prb.Listar())
                    {
                        Thread.Sleep(250);
                        if (elemento == null) Console.Write("# ");
                        else Console.Write($"{elemento} ");
                    }
                    Console.Write("\n\nPresione qualquer tecla para sair: ");
                    Console.ReadLine();

                    Thread.Sleep(1000);
                    Console.Clear();
                    break;
                
                // Push vermelho
                case 2:
                    Console.WriteLine("PUSH VERMELHO");
                    Console.Write("Digite o objeto a ser inserido: ");

                    prb.PushVermelho(Console.ReadLine());

                    Thread.Sleep(1000);
                    Console.Clear();
                    break;

                // Pop Vermelho
                case 3:
                    Console.WriteLine("POP VERMELHO");

                    Console.Write($"Valor removido foi: {prb.PopVermelho()}");

                    Thread.Sleep(1000);
                    Console.Clear();
                    break;
                
                // Push Preto
                case 4:
                    Console.WriteLine("PUSH PRETO");
                    Console.Write("Digite o objeto a ser inserido: ");

                    prb.PushPreto(Console.ReadLine());

                    Thread.Sleep(1000);
                    Console.Clear();
                    break;
                
                // Pop preto
                case 5:
                    Console.WriteLine("POP PRETO");

                    Console.Write($"Valor removido foi: {prb.PopPreto()}");

                    Thread.Sleep(1000);
                    Console.Clear();
                    break;
            }
        }

        Console.WriteLine("Fim do Programa!");

    }
}

class PilhaRubroNegra
{
    private object[] array;
    private int topVermelho;
    private int topPreto;
    private int capacidade;
    private int sizeVermelho = 0;
    private int sizePreto = 0;

    public PilhaRubroNegra(int capacidade)
    {
        array = new object[capacidade];
        topVermelho = -1;
        topPreto = capacidade;
        this.capacidade = capacidade;
    }

    public void PushVermelho(object valor)
    {
        // Vermelho chegou no final do array, ou seja, não houve pushPreto
        if (topVermelho == capacidade - 1)
        {
            object[] novoArray = new object[capacidade *= 2];

            for (int i = 0; i <= topVermelho; i++)
            {
                novoArray[i] = array[i];
            }

            // Começara a partir do fim do novo array
            topPreto = capacidade;

            array = novoArray;
        }

        else if (topVermelho == topPreto - 1)
        {
            int antigaCapacidade = capacidade;
            object[] novoArray = new object[capacidade *= 2];

            for (int i = 0; i <= topVermelho; i++)
            {
                novoArray[i] = array[i];
            }

            topPreto = capacidade - sizePreto;

            for (int i = capacidade - 1; i >= topPreto; i--)
            {
                antigaCapacidade--;
                novoArray[i] = array[antigaCapacidade];
            }

            array = novoArray;
        }
        topVermelho++;
        sizeVermelho++;
        array[topVermelho] = valor;
    }

    public void PushPreto(object valor)
    {
        // Quando o topPreto chegar no inicio do array
        if (topPreto == 0)
        {
            int antigaCapacidade = capacidade;
            object[] novoArray = new object[capacidade *= 2];

            for (int i = capacidade - 1; i >= capacidade / 2; i--)
            {
                antigaCapacidade--;
                novoArray[i] = array[antigaCapacidade];
            }

            // Ele ira começar a partir da antiga capacidade
            topPreto = capacidade / 2;

            array = novoArray;
        }

        // topPreto encostou com o topVermelho
        else if (topPreto == topVermelho + 1)
        {
            int antigaCapacidade = capacidade;
            object[] novoArray = new object[capacidade *= 2];

            for (int i = 0; i <= topVermelho; i++)
            {
                novoArray[i] = array[i];
            }

            topPreto = capacidade - sizePreto;

            for (int i = capacidade - 1; i >= topPreto; i--)
            {
                antigaCapacidade--;
                novoArray[i] = array[antigaCapacidade];
            }

            array = novoArray;
        }
        topPreto--;
        sizePreto++;
        array[topPreto] = valor;
    }

    public object PopVermelho()
    {
        // Adicionar excessao
        object auxiliar = array[topVermelho];
        // Atribuição para null para exibir "corretamente" o array
        array[topVermelho] = null;
        sizeVermelho--;
        topVermelho--;
        return auxiliar;
    }

    public object PopPreto()
    {
        // Adicionar excessao
        object auxiliar = array[topPreto];
        // Atribuição para null para exibir "corretamente" o array
        array[topPreto] = null;
        sizePreto--;
        topPreto++;
        return auxiliar;
    }

    public object[] Listar()
    {
        return array;
    }

    public int GetCapacity()
    {
        return capacidade;
    }

    public int GetSizeVermelho()
    {
        return sizeVermelho;
    }

   public int GetSizePreto()
    {
        return sizePreto;
    }
}