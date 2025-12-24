using System;
using System.Collections.Generic;

internal class Program
{
    static List<Produto> produtos = new List<Produto>();
    static int proximoId = 1;

    static void Main(string[] args)
    {
        string opcao;

        do
        {
            Console.Clear();
            Console.WriteLine("=== CRUD DE PRODUTOS ===");
            Console.WriteLine("1 - Cadastrar produto");
            Console.WriteLine("2 - Listar produtos");
            Console.WriteLine("3 - Atualizar produto");
            Console.WriteLine("4 - Excluir produto");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");
            opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1": CadastrarProduto(); break;
                case "2": ListarProdutos(); break;
                case "3": AtualizarProduto(); break;
                case "4": ExcluirProduto(); break;
                case "0": Console.WriteLine("Saindo do sistema..."); break;
                default: Console.WriteLine("Opção inválida!"); break;
            }

            if (opcao != "0")
            {
                Console.WriteLine("\nPressione ENTER para continuar...");
                Console.ReadLine();
            }

        } while (opcao != "0");
    }

    // ================= CRUD =================

    static void CadastrarProduto()
    {
        Console.Write("Nome do produto: ");
        string nome = Console.ReadLine();

        Console.Write("Preço: ");
        decimal preco = decimal.Parse(Console.ReadLine());

        Produto produto = new Produto
        {
            Id = proximoId++,
            Nome = nome,
            Preco = preco
        };

        produtos.Add(produto);

        Console.WriteLine("Produto cadastrado com sucesso!");
    }

    static void ListarProdutos()
    {
        if (produtos.Count == 0)
        {
            Console.WriteLine("Nenhum produto cadastrado.");
            return;
        }

        foreach (var p in produtos)
        {
            Console.WriteLine($"ID: {p.Id} | Nome: {p.Nome} | Preço: R$ {p.Preco}");
        }
    }

    static void AtualizarProduto()
    using System;

    internal class Program
    {
        private static ProdutoRepository repo = new ProdutoRepository();

        private static void Main(string[] args)
        {
            string opcao;

            do
            {
                Console.Clear();
                Console.WriteLine("=== CRUD DE PRODUTOS ===");
                Console.WriteLine("1 - Cadastrar produto");
                Console.WriteLine("2 - Listar produtos");
                Console.WriteLine("3 - Atualizar produto");
                Console.WriteLine("4 - Excluir produto");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CadastrarProduto();
                        break;

                    case "2":
                        ListarProdutos();
                        break;

                    case "3":
                        AtualizarProduto();
                        break;

                    case "4":
                        ExcluirProduto();
                        break;

                    case "0":
                        Console.WriteLine("Saindo do sistema...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                if (opcao != "0")
                {
                    Console.WriteLine("\nPressione ENTER para continuar...");
                    Console.ReadLine();
                }

            } while (opcao != "0");
        }

        // ================= CRUD =================

        static void CadastrarProduto()
        {
            Console.Write("Nome do produto: ");
            string nome = Console.ReadLine();

            Console.Write("Preço do produto: ");
            if (!decimal.TryParse(Console.ReadLine(), out var preco)) preco = 0m;

            var produto = new Produto
            {
                Nome = nome,
                Preco = preco
            };

            repo.Add(produto);

            Console.WriteLine("Produto cadastrado com sucesso!");
        }

        static void ListarProdutos()
        {
            var produtos = repo.GetAll();
            if (produtos.Count == 0)
            {
                Console.WriteLine("Nenhum produto cadastrado.");
                return;
            }

            Console.WriteLine("=== LISTA DE PRODUTOS ===");
            foreach (var produto in produtos)
            {
                Console.WriteLine($"ID: {produto.Id} | Nome: {produto.Nome} | Preço: R$ {produto.Preco}");
            }
        }

        static void AtualizarProduto()
        {
            Console.Write("Digite o ID do produto: ");
            if (!int.TryParse(Console.ReadLine(), out var id)) { Console.WriteLine("ID inválido"); return; }

            var produto = repo.Get(id);

            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado.");
                return;
            }

            Console.Write($"Novo nome ({produto.Nome}): ");
            var nome = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nome)) produto.Nome = nome;

            Console.Write($"Novo preço ({produto.Preco}): ");
            var precoStr = Console.ReadLine();
            if (decimal.TryParse(precoStr, out var preco)) produto.Preco = preco;

            repo.Update(produto);

            Console.WriteLine("Produto atualizado com sucesso!");
        }

        static void ExcluirProduto()
        {
            Console.Write("Digite o ID do produto: ");
            if (!int.TryParse(Console.ReadLine(), out var id)) { Console.WriteLine("ID inválido"); return; }

            if (repo.Delete(id))
            {
                Console.WriteLine("Produto removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }
    }
