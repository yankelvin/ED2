using BinaryTree.Class;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------ Binary Tree ------------");

            while (true)
            {
                Console.WriteLine("Qual exercício deseja rodar? [99 para sair]");
                Console.Write("Exercicio: ");
                var exercicio = int.Parse(Console.ReadLine());

                if (exercicio == 99)
                    break;

                switch (exercicio)
                {
                    case 2:
                        Exercicio02();
                        break;
                    case 3:
                        Exercicio03();
                        break;
                    default:
                        Console.WriteLine("Exercicio não definido.");
                        break;
                }
            }

            Console.WriteLine("Programa finalizado.");
        }

        public static void Exercicio02()
        {
            var binaryTree = new BinaryTree<int, string>();
            Console.Write("\nBem vindo ao seu cadastro de cidades!!!\n");

            while (true)
            {
                Console.WriteLine("O que você deseja fazer?");
                Console.WriteLine("1 - Cadastrar cidade");
                Console.WriteLine("2 - Buscar cidade");
                Console.WriteLine("3 - Listar cidades\n");

                var opcao = int.Parse(Console.ReadLine());

                if (opcao == 99)
                    break;

                switch (opcao)
                {
                    case 1:
                        CadastrarCidade(binaryTree);
                        break;
                    case 2:
                        BuscarCidade(binaryTree);
                        break;
                    case 3:
                        ListarCidades(binaryTree);
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                static void CadastrarCidade(BinaryTree<int, string> binaryTree)
                {
                    Console.Write("Informe o ID da cidade: ");
                    var id = int.Parse(Console.ReadLine());
                    Console.Write("Informe o Nome da cidade: ");
                    var nome = Console.ReadLine();
                    binaryTree.Add(id, nome);

                    Console.WriteLine("\nCidade cadastrada com sucesso!\n");
                }

                static void BuscarCidade(BinaryTree<int, string> binaryTree)
                {
                    Console.Write("Informe o ID da cidade: ");
                    var id = int.Parse(Console.ReadLine());
                    var cidade = binaryTree.Search(id);

                    if (cidade != null)
                        Console.WriteLine($"\nA cidade encontrada foi: {cidade.Data}\n");
                    else
                        Console.WriteLine("\nNenhuma cidade foi encontrada para esse ID\n");
                }

                static void ListarCidades(BinaryTree<int, string> binaryTree)
                {
                    Console.WriteLine("Qual tipo de listagem você deseja realizar?");
                    Console.WriteLine("O que você deseja fazer? ");
                    Console.WriteLine("1 - Pré Ordem");
                    Console.WriteLine("2 - Pós Ordem");
                    Console.WriteLine("3 - Simétrica\n");

                    var tipo = int.Parse(Console.ReadLine());

                    Console.WriteLine("");

                    var cidades = new List<Node<int, string>>();

                    switch (tipo)
                    {
                        case 1:
                            cidades = binaryTree.PreOrder();
                            break;
                        case 2:
                            cidades = binaryTree.AfterOrder();
                            break;
                        case 3:
                            cidades = binaryTree.SimetricOrder();
                            break;
                        default:
                            Console.WriteLine("Tipo de listagem inválida!");
                            break;
                    }

                    if (cidades.Any())
                        cidades.ForEach(x => Console.WriteLine($"\nId: {x.Data} | Cidade? {x.Key}"));
                }
            }
        }

        public static void Exercicio03()
        {
            var binaryTree = new BinaryTree<int, int>();
            Console.WriteLine("\n-------- Árvore com 2 milhões de nós --------");
            Console.WriteLine($"Iniciando inserção às {DateTimeOffset.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")}\n");

            Random rnd = new Random();

            for (int i = 0; i < 2000000; i++)
            {
                var random = rnd.Next(0, 2000000);
                binaryTree.AddIterative(random, i);
            }

            Console.WriteLine($"Inserção finalizada às {DateTimeOffset.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")}\n");

            while (true)
            {
                Console.WriteLine("O que você deseja fazer? [99 para sair]");
                Console.WriteLine("1 - Busca recursiva");
                Console.WriteLine("2 - Busca iterativa");

                var opcao = int.Parse(Console.ReadLine());

                Console.WriteLine("");
                if (opcao == 99)
                    break;

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Informe o índice que deseja buscar: ");
                        var indice = int.Parse(Console.ReadLine());

                        Console.WriteLine($"\nIniciando busca: {DateTimeOffset.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")}");
                        binaryTree.Search(indice);

                        Console.WriteLine($"Indice encontrado às {DateTimeOffset.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")}\n");
                        break;
                    case 2:
                        Console.WriteLine("Informe o índice que deseja buscar: ");
                        indice = int.Parse(Console.ReadLine());

                        Console.WriteLine($"\nIniciando busca: {DateTimeOffset.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")}");
                        binaryTree.SearchIterative(indice);

                        Console.WriteLine($"Indice encontrado às {DateTimeOffset.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")}\n");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }
    }
}
