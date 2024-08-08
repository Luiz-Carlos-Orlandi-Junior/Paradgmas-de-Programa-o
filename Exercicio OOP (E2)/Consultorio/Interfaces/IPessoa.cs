using System;



namespace Consultorio.Interfaces
{
    public interface IPessoa 
    {
 

        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Sexo { get; set; }
    }
}
