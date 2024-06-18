using Api.Database;
using Api.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Services
{

    public class NotFoundExcepition : Exception
    {
        public NotFoundExcepition() { }
    }

    public class ProdutoService
    {
        public readonly ContextDB _contextDB;
        public ProdutoService(ContextDB contextDB)
        {
            _contextDB = contextDB;
        }

        public List<Produto> GetAll()
        {
            return _contextDB.Produtos;
        }

        public Produto GetById(int codigo)
        {
            try
            {
                return _contextDB.Produtos.Where(p => p.Codigo == codigo)
                                           .First();
            }
            catch
            {
                throw new NotFoundExcepition();
            }
        }
    }
}
