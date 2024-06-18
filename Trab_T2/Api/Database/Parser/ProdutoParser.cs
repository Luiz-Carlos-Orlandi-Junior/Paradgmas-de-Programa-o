using Api.Database.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Api.Database.Parser
{
    public class ProdutoParser
    {
        public enum Header
        {
            codigo = 0,
            descricao = 1,
            categoria = 2,
            Preco = 3,
            estoque = 4,
            qtdVendida = 5,
        }

        public static List<Produto> ConverterLista(string arquivo)
        {
            List<Produto> produtos = new();

            var linhas = arquivo.Split('\n').ToList();

            linhas.Remove(linhas.First());

            foreach (var linha in linhas)
            {
                Produto produto = new Produto()
                {
                    Codigo = Convert.ToInt32(linha.Split(';')[(int)Header.codigo]),

                    Descricao = linha.Split(";")[(int)Header.descricao],

                    Categoria = linha.Split(";")[(int)Header.categoria],

                    Preco = Convert.ToDouble(linha.Split(";")[(int)Header.Preco], CultureInfo.InvariantCulture),

                    Estoque = Convert.ToInt32(linha.Split(";")[(int)Header.estoque]),

                    QtdVendida = Convert.ToInt32(linha.Split(";")[(int)Header.qtdVendida])

                };

                produtos.Add(produto);
            }

            return produtos;
        }

    }

}
