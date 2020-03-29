using System;
using System.Collections.Generic;

namespace LavaJato
{
    class Program
    {
        static void Main(string[] args)
        {
            var lj = new LavaJato();

            while (true)
            {
                Console.WriteLine("------------ LAVA JATO ------------");
                Console.WriteLine("1 - Cadastrar Suspeito");
                Console.WriteLine("2 - Adicionar Cúmplice");
                Console.WriteLine("3 - Listar cúmplices de um suspeito");
                Console.WriteLine("4 - Listar crimes de um suspeito");
                Console.WriteLine("5 - Listar suspeitos em comum entre duas partes");
                Console.WriteLine("6 - Informar alcance de um suspeito");
                Console.WriteLine("7 - Sair");


                Console.WriteLine("\nInforme a opção desejada: ");
                int opcao = Convert.ToInt32(Console.ReadLine());

                if (opcao == 7)
                    break;

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Nome do suspeito: ");
                        var nomeSuspeito = Console.ReadLine();

                        Console.WriteLine("Crimes (Separe por virgulas): ");
                        var stringao = Console.ReadLine();
                        var crimes = stringao.Split(",");

                        lj.AdicionarSuspeito(nomeSuspeito, new List<string>(crimes));

                        break;
                    case 2:
                        Console.WriteLine("Nome do suspeito: ");
                        nomeSuspeito = Console.ReadLine();

                        Console.WriteLine("Nome do cúmplice: ");
                        var nomeCumplice = Console.ReadLine();

                        Console.WriteLine("Crimes (Separe por virgulas): ");
                        stringao = Console.ReadLine();
                        crimes = stringao.Split(",");

                        lj.AdicionarCumplice(nomeSuspeito, nomeCumplice, new List<string>(crimes));

                        break;
                    case 3:
                        Console.WriteLine("Nome do suspeito: ");
                        nomeSuspeito = Console.ReadLine();

                        var cumplices = lj.ListarCumplices(nomeSuspeito);
                        Console.WriteLine("Cúmplices:");
                        foreach (var item in cumplices)
                            Console.WriteLine($"- {item}");

                        break;
                    case 4:
                        Console.WriteLine("Nome do suspeito: ");
                        nomeSuspeito = Console.ReadLine();

                        var crimesS = lj.ListarCrimes(nomeSuspeito);
                        Console.WriteLine("Crimes:");
                        foreach (var item in crimesS)
                            Console.WriteLine($"- {item}");

                        break;
                    case 5:
                        Console.WriteLine("Nome do suspeito 1: ");
                        var nomeSuspeito1 = Console.ReadLine();

                        Console.WriteLine("Nome do suspeito 2: ");
                        var nomeSuspeito2 = Console.ReadLine();

                        var comum = lj.ListarSuspeitosComum(nomeSuspeito1, nomeSuspeito2);

                        Console.WriteLine("Em comum:");
                        foreach (var item in comum)
                            Console.WriteLine($"- {item}");
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }
    }
}
