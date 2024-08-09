using Consultorio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Classes
{
    public class CSecretaria : ISecretaria
    {
        private string _nome;
        private string _cpf;
        private string _sexo;


        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        public string CPF
        {
            get { return _cpf; }
            set { _cpf = value; }
        }
        public string Sexo
        {
            get { return _sexo; }
            set { _sexo = value; }
        }



        public void MarcarConsulta()
        {
    
        }


    }
}
