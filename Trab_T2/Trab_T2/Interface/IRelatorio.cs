using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trab_T2.Classes;

namespace Trab_T2.Interface
{
    public interface IRelatorio
    {
        List<Produto> Imprimir(List<Produto> produto);
    }
}
