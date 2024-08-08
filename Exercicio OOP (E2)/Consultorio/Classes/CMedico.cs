using Consultorio.Interfaces;
using System;
using System.Security;

namespace Consultorio.Classes
{
    public class CMedico : IMedico
    {
        private string _nome;
        private string _especializacao;
        private string _licenca;
        private string _sexo;
        private string _cpf;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        public string Especializacao
        {
            get { return _especializacao; }
            set { _especializacao = value; }
        }

        public string Licensa
        {
            get { return _licenca; }
            set { _licenca = value; }
        }
        
        public string Sexo
        {
            get { return _sexo; }
            set { _sexo = value; }
        }

        public string CPF
        {
            get { return _cpf; }
            set { _cpf = value; }
        }

        public void Assinar()
        {
            Console.WriteLine("Assinado");
        }
        public virtual void Diagnosticar()
        {
            Console.WriteLine($"Dr {Nome}, Sexo: {Sexo}, Especialização: {Especializacao}, Numero da licensa: {Licensa}");
        }
    }
}
