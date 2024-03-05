using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        PilhaRubroNegra prb = new PilhaRubroNegra(8);

        int comando = 0;
        while (comando != 99)
        {
            // Interface do usuario
            Console.WriteLine(
                "Menu\n" +
                "1-Listar\n" +
                "2-Push Vermelho\n" +
                "3-Push Preta\n" +
                "4-Pop Vermelho\n" +
                "5-Pop Preta");

            Console.Write("Selecione o valor da operação desejada: ");
            comando = int.Parse(Console.ReadLine());

            Thread.Sleep(1000);
            Console.Clear();

            switch (comando)
            {
                // Listar
                case 1:
                    foreach (object elemento in prb.Listar())
                    {
                        Thread.Sleep(250);
                        if (elemento == null) Console.Write("# ");
                        else Console.Write($"{elemento} ");
                    }
                    Console.WriteLine();

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

                // Push preta
                case 3:
                    Console.WriteLine("PUSH PRETA");
                    Console.Write("Digite o objeto a ser inserido: ");

                    prb.PushPreta(Console.ReadLine());

                    Thread.Sleep(1000);
                    Console.Clear();
                    
                    break;
                
                // Pop preta
                case 4:
                    Console.WriteLine("POP PRETA");

                    Console.Write($"Valor removido foi: {prb.PopPreta()}");

                    Thread.Sleep(1000);
                    Console.Clear();

                    break;

                // Pop vermelho
                case 5:
                    Console.WriteLine("POP VERMELHO");

                    Console.Write($"Valor removido foi: {prb.PopVermelho()}");

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
    private int topPreta;
    public PilhaRubroNegra(int tamanho)
    {
        array = new object[tamanho];
        topVermelho = -1;
        topPreta = tamanho;
    }

    public void PushVermelho(object valor)
    {
        topVermelho++;
        array[topVermelho] = valor;
    }

    public void PushPreta(object valor)
    {
        topPreta--;
        array[topPreta] = valor;
    }

    public object PopVermelho()
    {
        object auxiliar = array[topVermelho];
        topVermelho--;
        return auxiliar;
    }

    public object PopPreta()
    {
        object auxiliar = array[topPreta];
        topPreta--;
        return auxiliar;
    }

    public object[] Listar()
    {
        return array;
    }
}