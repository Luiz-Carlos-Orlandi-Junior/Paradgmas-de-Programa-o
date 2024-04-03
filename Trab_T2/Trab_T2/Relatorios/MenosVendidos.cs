using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trab_T2.Classes;
using Trab_T2.Interface;

namespace Trab_T2.Relatorios
{
    public class MenosVendidos : IRelatorio
    {
        public List<Produto> Imprimir(List<Produto> produtos)
        {
                return
                produtos.OrderBy(p => p.QtdVendida).Take(5).ToList();
        }
    }
}
