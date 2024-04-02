using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Trab_T2.Classes
{
    public class ProdutoParser
    {
        public enum Header
        {
            codigo = 0,
            descricao = 1,
            categoria = 2,
            preco = 3,
            estoque = 4,
            qtdVendida = 5,
        }

        public static List<Produto> ConverterLista(string arquivo)
        {
            List<Produto> produtos = new();

            var linhas = arquivo.Split('\n').ToList();

            linhas.Remove(linhas.First());

            foreach ( var linha in linhas)
            {
                Produto produto = new Produto()
                {
                    Codigo = Convert.ToInt32(linha.Split(';')[(int)Header.codigo]),

                    Descricao = linha.Split(";")[(int)Header.descricao],   

                    Categoria = linha.Split(";")[(int)Header.categoria],

                    Preco = Convert.ToDouble(linha.Split(";")[(int)Header.preco]),

                    Estoque = Convert.ToInt32(linha.Split(";")[(int)Header.estoque]),

                    QtdVendida = Convert.ToInt32(linha.Split(";")[(int)Header.qtdVendida])
                    
                };

                produtos.Add(produto);
            }

            return produtos;
        }
 
    }

}
