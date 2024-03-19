using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        Console.WriteLine(
            "1-Testar a pilha manualmente\n" +
            "2-Calcular entradas enormes"
        );
        Console.Write("Selecione uma opção: ");
        int escolha = int.Parse(Console.ReadLine());

        Console.Clear();

        if (escolha == 1)
        {
            Console.WriteLine("Bem-vindo ao TAD Pilha");

            // Instanciando a pilha que será usada
            Pilha p = new Pilha();

            while (true)
            {
                Console.WriteLine(
                    "---------Menu---------\n" +
                    "1-Show\n" +
                    "2-Push\n" +
                    "3-Pop\n" +
                    "4-Top\n" +
                    "5-Empty\n" +
                    "99-Sair\n" +
                    "----------------------"
                );
                Console.Write("Selecione uma opção: ");
                int x = int.Parse(Console.ReadLine());

                // Fim do Programa
                if (x == 99) break;

                Thread.Sleep(1000);
                Console.Clear();

                switch (x)
                {
                    case 1:
                        Console.WriteLine(
                            $"Capacidade: {p.Capacity()}\n" +
                            $"Quantidade de elementos: {p.Size()}\n" +
                            $"Está vazio: {p.IsEmpty()}\n" +
                            $"Elementos da pilha:"
                        );

                        p.Show();

                        Console.Write($"Digite qualquer tecla para sair: ");
                        Console.ReadLine();
                        
                        Console.Clear();             
                        break;
                    case 2:
                        Console.Write(
                            "PUSH\n" +
                            "Digite um objeto a ser armazenado: "
                        );
                        object o = Console.ReadLine();
                        p.Push(o);

                        Thread.Sleep(1000);
                        Console.Clear();  
                        break;
                    case 3:
                        Console.WriteLine(
                            "POP\n" +
                            $"Objeto removido foi: {p.Pop()}"
                        );

                        Thread.Sleep(1000);
                        Console.Clear();           
                        break;
                    case 4:
                        Console.WriteLine(
                            "TOP\n" +
                            $"O elemento do topo é: {p.Top()}"
                        );

                        Thread.Sleep(1000);
                        Console.Clear();   
                        break;
                    case 5:
                        Console.WriteLine("EMPTY");
                        p.Empty();
                        Console.WriteLine("Pilha esvaziada com sucesso!");

                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
            }
        }

        else if (escolha == 2)
        {
            Pilha p = new Pilha();

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
                
                Console.WriteLine($"Tempo decorrido: {tempoDecorrido}");
            }
            else
            {
                Console.WriteLine("Arquivo não existente");
            }
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

        else if (Size() == (int)(capacidade * 0.25))
        {
            capacidade /= 2;
            object[] arrayAux = new object[capacidade];

            for (int i = 0; i <= topo; i++)
            {
                arrayAux[i] = array[i];
            }

            array = arrayAux;
        }

        // Atribuição para null, para exibir os elementos corretamente
        object aux = array[topo];
        array[topo] = null;
        topo--;
        return aux;
    }

    public int Capacity() { return capacidade; }

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

    public void Empty()
    {
        object[] novoArray = new object[1];
        topo = -1;
        capacidade = 1;
        array = novoArray;
    }
    
    public void Show()
    {
        Console.Write("[");
        for (int i = 0; i < Capacity(); i++)
        {
            if (i == 0)
            {
                if (array[i] == null) Console.Write("#");
                else Console.Write(array[i]);
            }
            else 
            {   
                if (array[i] == null) Console.Write(", #");
                else Console.Write($", {array[i]}");
            }
        }
        Console.WriteLine("]");
    }
}
