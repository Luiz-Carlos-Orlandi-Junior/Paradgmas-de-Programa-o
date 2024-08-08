using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criptografia.Interfaces
{
    // Interface para criptografia de arquivos
    public interface ICriptografiaArquivo
    {
        void CriptografarArquivo(string caminhoArquivo);
        void DescriptografarArquivo(string caminhoArquivo);
    }
}
