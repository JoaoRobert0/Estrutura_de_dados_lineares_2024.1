using System;

namespace _1_Pilha
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Bem-Vindo a estrutura de dados: PILHA");
            Console.WriteLine("Digite o tamanho inicial da sua pilha: ");
            int tamanho = int.Parse(Console.ReadLine());
            Pilha pilha = new Pilha(tamanho);
            while (true)
            {
                Console.WriteLine(
                "Funções:\n
                1 - Inserir elemento\n
                2 - Visualizar e remover o ultimo elemento\n
                3 - Exibir pilha\n
                4 - Ver o ultimo elemento\n
                5 - Visualizar a quantidade de elemento\n
                6 - Retornar se a pilha está vazia\n
                7 - Sair\n
                Selecione uma das opções: ");

                int switch_on = int.Parse(Console.ReadLine());
                switch (switch_on)
                {
                    case 1:
                        Console.WriteLine(
                            "INSERIR ELEMENTO\n
                            Digite o valor a ser adicionado: ");
                        int value = int.Parse(Console.ReadLine());
                        pilha.Push(value);
                        Console.WriteLine("Valor adicionado com sucesso");
                        break;
                    case 2:
                        Console.WriteLine("VISUALIZAR E REMOVER O ULTIMO ELEMENTO\n");
                        Console.WriteLine($"Valor removido: {pilha.Pop()}");
                        break;
                    case 3:
                        Console.WriteLine("EXIBIR PILHA");
                        foreach (int item in pilha.Pop())
                        {
                            Console.Write($"{item} ");
                        }
                        Console.WriteLine();
                }
            }

        }
    }

    class Pilha
    {
        private int top = -1;
        private int[] array;

        public Pilha(int tam)
        {
            array = new int[tam];
        }

        public void Push(int value)
        {
            top++;
            array[top] = value;
        }

        public int Pop()
        {
            int value = array[top];
            top--;
            return value;
        }

        public int Top()
        {
            return array[top];
        }

        public int Size()
        {
            return top + 1;
        }

        public bool IsEmpty()
        {
            if (top == -1) return true;
            return false;
        }

        public int[] Show()
        {
            return array;
        }
    }
}
