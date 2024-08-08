using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Interfaces
{
    public interface IConsulta
    {
        public string Finalidade {  get; set; }
        public string Horario {  get; set; }
        public string Local {  get; set; }
        public IMedico Medico { get; set; }
        public IPaciente Paciente {  get; set; } 
        
    }
}
