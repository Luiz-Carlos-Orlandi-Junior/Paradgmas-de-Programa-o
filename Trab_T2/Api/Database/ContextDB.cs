using Api.Database.Models;
using Api.Database.Parser;
using System.Collections.Generic;
using System.IO;

namespace Api.Database
{
    public class ContextDB
    {
        private readonly string _Dataset;
        private readonly List<Produto> _produtos;

        public ContextDB()
        {
            _Dataset = File.ReadAllText("Dataset.csv");
            _produtos = ProdutoParser.ConverterLista(_Dataset);
        }

        public List<Produto> Produtos => _produtos;
    }
}
