using ABB.models;
using BinaryTree.Class;
using GenericTree.Class;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABB
{
    public class Sistema
    {
        public Tree<string, BinaryTree<string, Produto>> Produtos { get; private set; }
        public BinaryTree<string, Comprador> Compradores { get; private set; }

        public Sistema()
        {
            Produtos = new Tree<string, BinaryTree<string, Produto>>("ROOT", new BinaryTree<string, Produto>());

            Produtos.AddNode("ROOT", "SCOOTER", new BinaryTree<string, Produto>());
            Produtos.AddNode("ROOT", "NAKED", new BinaryTree<string, Produto>());
            Produtos.AddNode("ROOT", "SPORT", new BinaryTree<string, Produto>());

            Produtos.AddNode("ROOT", "HATCH", new BinaryTree<string, Produto>());
            Produtos.AddNode("ROOT", "SEDAN", new BinaryTree<string, Produto>());
            Produtos.AddNode("ROOT", "SUV", new BinaryTree<string, Produto>());

            Compradores = new BinaryTree<string, Comprador>();
        }

        public void Iniciar()
        {
            while (true)
            {
                Console.WriteLine("\n----------- Sistema ABB -----------");
                Console.WriteLine("1 - Cadastrar produto");
                Console.WriteLine("2 - Cadastrar comprador");
                Console.WriteLine("3 - Vender produto");
                Console.WriteLine("4 - Consultar produto (Chassi)");
                Console.WriteLine("5 - Consultar produtos do comprador (CPF)");
                Console.WriteLine("6 - Listar motocicletas disponíveis");
                Console.WriteLine("7 - Listar motocicletas vendidas");
                Console.WriteLine("8 - Listar automóveis disponíveis");
                Console.WriteLine("9 - Listar automóveis vendidos");
                Console.WriteLine("Digite 0 para sair.");

                Console.Write("\nOpção: ");
                int opcao = Convert.ToInt32(Console.ReadLine());

                if (opcao == 0)
                {
                    Console.WriteLine("\nSistema encerrado.");
                    return;
                }

                Console.WriteLine();

                switch (opcao)
                {
                    case 1:
                        CadastrarProduto();
                        break;
                    case 2:
                        CadastrarComprador();
                        break;
                    case 3:
                        VenderProduto();
                        break;
                    case 4:
                        ConsultarProdutoChassi();
                        break;
                    case 5:
                        ConsultarProdutosDoComprador();
                        break;
                    case 6:
                        ListarMotocicletas(true);
                        break;
                    case 7:
                        ListarMotocicletas(false);
                        break;
                    case 8:
                        ListarAutomoveis(true);
                        break;
                    case 9:
                        ListarAutomoveis(false);
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida.");
                        break;
                }
            }
        }

        private void CadastrarProduto()
        {
            Console.WriteLine("----------- Cadastrar Produto -----------");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Ano de fabricação: ");
            int anoFabricacao = Convert.ToInt32(Console.ReadLine());
            Console.Write("Número do chassi: ");
            string chassi = Console.ReadLine();
            Console.WriteLine("\nTipo do automóvel");
            Console.Write("1 - Motocicleta | 2 - Automóvel: ");
            int tipo = Convert.ToInt32(Console.ReadLine());
            Categoria categoria;
            switch (tipo)
            {
                case 1:
                    Console.WriteLine("\n1 - Scooter");
                    Console.WriteLine("2 - Naked");
                    Console.WriteLine("3 - Sport\n");
                    categoria = (Categoria)Convert.ToInt32(Console.ReadLine()) - 1;
                    break;
                case 2:
                    Console.WriteLine("\n1 - Hatch");
                    Console.WriteLine("2 - Sedan");
                    Console.WriteLine("3 - SUV\n");
                    categoria = (Categoria)Convert.ToInt32(Console.ReadLine()) + 2;
                    break;
                default:
                    Console.WriteLine("Categoria inválida!");
                    return;
            }

            var produto = new Produto()
            {
                Nome = nome,
                AnoFabricacao = anoFabricacao,
                Chassi = chassi,
                Categoria = categoria
            };

            var repository = Produtos.SearchNode(categoria.ToString().ToUpper()).Data;
            repository.Add(chassi, produto);

            Console.WriteLine("\nProduto cadastrado com sucesso!\n");
        }

        private void CadastrarComprador()
        {
            Console.WriteLine("\n----------- Cadastrar Comprador -----------");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("CPF: ");
            string cpf = Console.ReadLine();

            var comprador = new Comprador()
            {
                Nome = nome,
                CPF = cpf
            };

            Compradores.Add(cpf, comprador);

            Console.WriteLine("\nComprador cadastrado com sucesso!\n");
        }

        private void VenderProduto()
        {
            Console.WriteLine("----------- Vender Produto -----------");
            Console.Write("CPF do comprador: ");
            string cpf = Console.ReadLine();
            var comprador = Compradores.Search(cpf).Data;

            Console.Write("Número do chassi: ");
            string chassi = Console.ReadLine();
            Console.WriteLine("Tipo do automóvel");
            Console.Write("1 - Motocicleta | 2 - Automóvel: ");
            int tipo = Convert.ToInt32(Console.ReadLine());
            Categoria categoria;
            switch (tipo)
            {
                case 1:
                    Console.WriteLine("1 - Scooter");
                    Console.WriteLine("2 - Naked");
                    Console.WriteLine("3 - Sport\n");
                    categoria = (Categoria)Convert.ToInt32(Console.ReadLine()) - 1;
                    break;
                case 2:
                    Console.WriteLine("1 - Hatch");
                    Console.WriteLine("2 - Sedan");
                    Console.WriteLine("3 - SUV\n");
                    categoria = (Categoria)Convert.ToInt32(Console.ReadLine()) + 2;
                    break;
                default:
                    Console.WriteLine("Categoria inválida!");
                    return;
            }

            var produto = Produtos.SearchNode(categoria.ToString().ToUpper()).Data.Search(chassi).Data;
            produto.Comprador = comprador;
            comprador.Produtos.Add(produto);
        }

        private void ConsultarProdutoChassi()
        {
            Console.WriteLine("\n----------- Consultar Produto pelo Chassi -----------");
            Console.Write("Chassi: ");
            string chassi = Console.ReadLine();

            var categorias = Produtos.GetNodes();
            foreach (var cat in categorias)
            {
                var produto = cat.Data.Search(chassi);
                if (produto != null)
                {
                    Console.WriteLine(produto.Data.ToString() + "\n");
                    return;
                }
            }

            Console.WriteLine("Produto não encontrado!");
        }

        private void ConsultarProdutosDoComprador()
        {
            Console.WriteLine("\n----------- Consultar Produto do Comprador -----------");
            Console.Write("CPF: ");
            string cpf = Console.ReadLine();

            var comprador = Compradores.Search(cpf).Data;
            foreach (var prod in comprador.Produtos)
            {
                Console.WriteLine(prod.ToString());
            }
        }

        private void ListarMotocicletas(bool disponivel)
        {
            string texto = disponivel ? "Disponíveis" : "Vendidas";
            Console.WriteLine($"\n----------- Listar Motocicletas {texto} -----------");
            var categorias = new List<string>() { "SCOOTER", "NAKED", "SPORT" };

            var produtos = Produtos.GetNodes();
            foreach (var prod in produtos)
            {
                if (categorias.Contains(prod.Ind))
                {
                    var motos = prod.Data.PreOrder();
                    foreach (var moto in motos)
                    {
                        if ((disponivel && moto.Data.Comprador == null) || (!disponivel && moto.Data.Comprador != null))
                            Console.WriteLine(moto.Data.ToString() + "\n");
                    }
                }
            }
        }

        private void ListarAutomoveis(bool disponivel)
        {
            string texto = disponivel ? "Disponíveis" : "Vendidos";
            Console.WriteLine($"\n----------- Listar Automóveis {texto} -----------");
            var categorias = new List<string>() { "HATCH", "SEDAN", "SUV" };

            var produtos = Produtos.GetNodes();
            foreach (var prod in produtos)
            {
                if (categorias.Contains(prod.Ind))
                {
                    var automoveis = prod.Data.PreOrder();
                    foreach (var auto in automoveis)
                    {
                        if ((disponivel && auto.Data.Comprador == null) || (!disponivel && auto.Data.Comprador != null))
                            Console.WriteLine(auto.Data.ToString() + "\n");
                    }
                }
            }
        }
    }
}
