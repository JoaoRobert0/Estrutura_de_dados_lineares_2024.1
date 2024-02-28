using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("1-Calcular tempo com grandes entradas\n2-Visualizar pilha");
        Console.Write("Selecione uma opção: ");
        int escolha = int.Parse(Console.ReadLine());
        if (escolha == 1)
        {
            Pilha p = new Pilha(1000000);

            Stopwatch stopWatch = new Stopwatch();
            
            // Nome do arquivo que sera lido
            string caminhoArquivo = @"..\Testes\teste_100000_1.dat";

            if (File.Exists(caminhoArquivo))
            {
                stopWatch.Start();

                using (StreamReader sr = new StreamReader(caminhoArquivo))
                {
                    string linha;
                    while ((linha = sr.ReadLine()) != null)
                    {
                        int valor = int.Parse(linha);
                        p.Push(valor);
                    }
                }
                stopWatch.Stop();
                TimeSpan tempoDecorrido = stopWatch.Elapsed;
                
                Console.WriteLine(tempoDecorrido);
            }
            else
            {
                Console.WriteLine("Arquivo não existente");
            }
            
        }
        else
        {
            Console.WriteLine("Bem-vindo ao TAD Pilha");
            Console.WriteLine("Antes de testar o programa,\ninforme um valor inicial para a capacidade da pilha");
            Console.Write("Capacidade = ");

            int x = int.Parse(Console.ReadLine());
            if (x <= 0) throw new Exception("Valor invalido!");

            Pilha p = new Pilha(x);

            Console.Clear();
            while (true)
            {
                Console.WriteLine("1-Push\n2-Pop\n3-Show\n4-Size\n5-Empty\n6-Top\n7-Capacity\n8-Clear");
                Console.Write("Selecione uma opção: ");
                try{
                    x = int.Parse(Console.ReadLine());
                }catch (Exception ex){
                    Console.WriteLine("Digite novamente, um numero entre as opções");
                }
                switch (x)
                {
                    case 1:
                        Console.WriteLine("Digite um objeto a ser armazenado: ");
                        object o = Console.ReadLine();
                        p.Push(o);
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.WriteLine($"Objeto removido foi: {p.Pop()}\n");
                        break;
                    case 3:
                        p.Show();
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.WriteLine(p.Size());
                        Console.WriteLine();
                        break;
                    case 5:
                        Console.WriteLine(p.IsEmpty());
                        Console.WriteLine();
                        break;
                    case 6:
                        Console.WriteLine(p.Top());
                        Console.WriteLine();
                        break;
                    case 7:
                        Console.WriteLine(p.Capacity());
                        Console.WriteLine();
                        break;
                    case 8:
                        Console.Clear();
                        break;
                }
            }
        }
    }
}

class Pilha
{
    private object[] array;
    private int topo;
    private int capacide;
    public Pilha(int tam)
    {
        array = new object[tam];
        capacide = tam;
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
        if (topo == capacide - 1)
        {
            // Estrategia de duplicação
            // Testar as outras estrategias
            capacide *= 2;
            object[] arrayAux = new object[capacide];
            
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
        for (int i = topo; i > -1; i--)
        {
            Console.WriteLine(array[i]);
        }
    }

    public int Capacity()
    {
        return capacide;
    }

}
