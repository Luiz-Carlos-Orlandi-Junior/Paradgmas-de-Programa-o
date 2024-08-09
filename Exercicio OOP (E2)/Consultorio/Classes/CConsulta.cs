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
    }
}
