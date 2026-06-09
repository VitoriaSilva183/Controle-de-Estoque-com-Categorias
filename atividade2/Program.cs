using ControleEstoque.Models;
using ControleEstoque.Repositories;

var categoriaRepo = new CategoriaRepository();
var produtoRepo = new ProdutoRepository();

while (true)
{
    Console.WriteLine("\n--- Controle de Estoque ---");
    Console.WriteLine("1. Cadastrar Categoria");
    Console.WriteLine("2. Listar Categorias");
    Console.WriteLine("3. Cadastrar Produto");
    Console.WriteLine("4. Listar Produtos");
    Console.WriteLine("5. Buscar Produto por ID");
    Console.WriteLine("6. Remover Produto");
    Console.WriteLine("0. Sair");

    Console.Write("Escolha uma opção: ");
    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            var categoria = new Categoria();
            Console.Write("Nome: ");
            categoria.Nome = Console.ReadLine();
            Console.Write("Descrição: ");
            categoria.Descricao = Console.ReadLine();
            categoriaRepo.Inserir(categoria);
            Console.WriteLine("Categoria cadastrada com sucesso!");
            break;

        case "2":
            var categorias = categoriaRepo.ListarTodos();
            foreach (var c in categorias)
            {
                Console.WriteLine($"Id: {c.Id} | Nome: {c.Nome} | Descrição: {c.Descricao}");
            }
            break;

        case "3":
            var produto = new Produto();
            Console.Write("Nome: ");
            produto.Nome = Console.ReadLine();
            Console.Write("Preço: ");
            produto.Preco = decimal.Parse(Console.ReadLine());
            Console.Write("Quantidade: ");
            produto.Quantidade = int.Parse(Console.ReadLine());
            Console.Write("ID da Categoria: ");
            produto.CategoriaId = int.Parse(Console.ReadLine());
            produtoRepo.Inserir(produto);
            Console.WriteLine("Produto cadastrado com sucesso!");
            break;

        case "4":
            var produtos = produtoRepo.ListarTodos();
            foreach (var p in produtos)
            {
                Console.WriteLine($"Id: {p.Id} | Nome: {p.Nome} | Preço: {p.Preco} | Quantidade: {p.Quantidade} | CategoriaId: {p.CategoriaId}");
            }
            break;

        case "5":
            Console.Write("ID do Produto: ");
            int idBusca = int.Parse(Console.ReadLine());
            var produtoEncontrado = produtoRepo.BuscarPorId(idBusca);
            if (produtoEncontrado != null)
            {
                Console.WriteLine($"Id: {produtoEncontrado.Id} | Nome: {produtoEncontrado.Nome} | Preço: {produtoEncontrado.Preco} | Quantidade: {produtoEncontrado.Quantidade}");
            }
            else
            {
                Console.WriteLine("Produto não encontrado!");
            }
            break;

        case "6":
            Console.Write("ID do Produto para remover: ");
            int idRemover = int.Parse(Console.ReadLine());
            produtoRepo.Remover(idRemover);
            Console.WriteLine("Produto removido com sucesso!");
            break;

        case "0":
            return;

        default:
            Console.WriteLine("Opção inválida!");
            break;
    }
}
