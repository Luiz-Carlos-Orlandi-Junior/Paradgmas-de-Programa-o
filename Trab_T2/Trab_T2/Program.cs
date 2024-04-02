using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using Trab_T2.Classes;

// Acessando o arquivo CSV
var dataSet = File.ReadAllText("..\\..\\..\\dataset.csv");

// Manipulando alguns pontos dos dados do arquivo CSV
var listaProdutos = ProdutoParser.ConverterLista(dataSet);


bool sair = false;

// Menu dos Relatorios
while (!sair)
{
    Console.WriteLine("Selecione uma opção de Relatorio: \n");
    Console.WriteLine("(1). Produtos mais vendidos");
    Console.WriteLine("(2). Produtos com mais estoque");
    Console.WriteLine("(3). Categoria mais vendida");
    Console.WriteLine("(4). Produtos menos vendidos");
    Console.WriteLine("(5). Estoque de segurança");
    Console.WriteLine("(6). Excesso de estoque");
    Console.WriteLine("(7). Média de preço por categoria");
    Console.WriteLine("(8). Sair");

    string opcao = Console.ReadLine();

    // Relatorio 1
    static void MaisVendidos(List<Produto> produtos)
    {
        var maisVendidos = produtos.OrderByDescending(p => p.QtdVendida).Take(5);

        foreach (var produto in maisVendidos)
        {
            Console.WriteLine($" Codigo do Produto: {produto.Codigo} | Descrição do produto: {produto.Descricao}");
        }
    }

    // Relatorio 2
    static void MaisEstoque(List<Produto> produtos)
    {
        var maisEstoque = produtos.OrderByDescending(p => p.Estoque).Take(3);

        foreach (var produto in maisEstoque)
        {
            Console.WriteLine($" Codigo do Produto: {produto.Codigo} | Descrição do produto: {produto.Descricao} | Estoque do produto: {produto.Estoque}");
        }
    }

    // Relatorio 3
    static void CategoriaMaisVendida(List<Produto> produtos)
    {
        var maisCategoria = produtos.OrderByDescending(p => p.Categoria).Take(1);

        foreach (var produto in maisCategoria)
        {
            Console.WriteLine($" Categoria: {produto.Categoria}");
        }
    }

    // Relatorio 4
    static void MenosVendidos(List<Produto> produtos)
    {
        var menosVendidos = produtos.OrderBy(p => p.QtdVendida).Take(5);

        foreach (var produto in menosVendidos)
        {
            Console.WriteLine($" Codigo do Produto: {produto.Codigo} | Descrição do produto: {produto.Descricao} | Quantidade vendida do produto: {produto.QtdVendida}");
        }
    }

    // Relatorio 5
    static void EstoqueSeguranca(List<Produto> produtos)
    {
        var produtosEstoqueSeguranca = produtos.Where(p => p.Estoque < p.QtdVendida * 0.33);

        foreach (var produto in produtosEstoqueSeguranca)
        {
            Console.WriteLine($"Código: {produto.Codigo} - Descrição: {produto.Descricao}: Estoque de Segurança: {produto.Estoque}");
        }
    }

    // Relatorio 6
    static void EstoqueAlto(List<Produto> produtos)
    {
        var produtosEstoqueAlto = produtos.Where(p => p.Estoque >= p.QtdVendida * 3);

        foreach (var produto in produtosEstoqueAlto)
        {
            Console.WriteLine($"Código: {produto.Codigo} - Descrição: {produto.Descricao}: Estoque: {produto.Estoque}");
        }
    }

    // Relatorio 7
    static void MediaPorCategoria(List<Produto> produtos)
    {
            var MediaPrecoPorCategoria = produtos
            .GroupBy(produto => produto.Categoria)
            .Select(CategoriaAgrupada => new
            {
                Categoria = CategoriaAgrupada.Key,
                Media = CategoriaAgrupada.Average(p => p.Preco)
            });

        foreach (var categoria in MediaPrecoPorCategoria)
        {
            Console.WriteLine(String.Format("{0}: {1:n2}", categoria.Categoria, categoria.Media));
        }
    }

    // Funcionamento das possiveis escolhas de Relatorio
    switch (opcao)
    {
        case "1":

            MaisVendidos(listaProdutos);
            break;
        case "2":
            MaisEstoque(listaProdutos);
            break;
        case "3":
            CategoriaMaisVendida(listaProdutos);
            break;
        case "4":
            MenosVendidos(listaProdutos);
            break;
        case "5":
            EstoqueSeguranca(listaProdutos);
            break;
        case "6":
            EstoqueAlto(listaProdutos);
            break;
        case "7":
            MediaPorCategoria(listaProdutos);
            break;
        case "8":
            Console.WriteLine("Fechando a aplicação...");
            sair = true;
            break;
        default:
            Console.WriteLine("Opção inválida. Por favor, selecione novamente.");
            break;
    }

    Console.WriteLine("\nPressione qualquer tecla para continuar...");
    Console.ReadLine();
    Console.Clear();
}