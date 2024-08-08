using Consultorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Classes
{
    public class CConsulta : IConsulta
    {
        private string _finalidade;
        private string _horario;
        private string _local;
        private IPaciente _paciente;
        private IMedico _medico;

        public string Finalidade
        {
            get { return _finalidade; }
            set { _finalidade = value; }
        }

        public string Horario
        {
            get { return _horario; }
            set { _horario = value; }
        }
        public string Local
        {
            get { return _local; }
            set { _local = value; }
        }

        public IPaciente Paciente
        {
            get { return _paciente; }
            set { _paciente = value; }
        }

        public IMedico Medico
        {
            get { return _medico; }
            set { _medico = value; }
        }
    }
}
