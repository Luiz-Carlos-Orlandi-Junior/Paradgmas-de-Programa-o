using Consultorio.Interfaces;
using System;

namespace Consultorio.Classes
{
    public class CEnfermeira : IPessoa
    {

        private string _registroEnfermeira;
        private string _setor;
        private string _nome;
        private string _cpf;
        private string _sexo;
        private string _especializacao;
      
        public string Especializacao
        {
            get { return _especializacao;}
            set { _especializacao = value;}
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

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        public string RegistroEnfermeira
        {
            get { return _registroEnfermeira; }
            set { _registroEnfermeira = value;}

        }
        public string Setor
        {
            get { return _setor; }
            set { _setor = value;}
        }
        public void AdministrarMedicacao()
        {
            
        }
    }
}
