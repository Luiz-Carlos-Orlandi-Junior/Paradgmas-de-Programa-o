using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Interfaces
{
    public interface ISecretaria : IPessoa
    {
        public void MarcarConsulta();
    }
}
