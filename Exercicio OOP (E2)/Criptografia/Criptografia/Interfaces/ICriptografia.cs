using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criptografia.Interfaces
{
    // Interface para criptografia de texto
    public interface ICriptografia
    {
        byte[] CriptografarTexto(string texto);
        string DescriptografarTexto(byte[] textoCriptografado);
    }
}
