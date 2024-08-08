using Consultorio.Interfaces;
using System;

namespace Consultorio.Classes
{

    public class CPaciente : IPessoa
    {
        private string _nome;
        private string _cpf;
        private string _sexo;
        private string _numConvenio;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        public string CPF
        {
            get { return _cpf; }
            set {_cpf = value; }
        }

        public string Sexo
        {
            get { return _sexo; }
            set { _sexo = value; }
        }
    
        string NumConvenio
        {
            get { return _numConvenio; }
            set { _numConvenio = value;}
        }
        
        
    }
}
