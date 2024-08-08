using System;



namespace Consultorio.Interfaces
{
    public interface IPessoa 
    {

        string Nome { get; set; }
        string CPF { get; set; }
        string Sexo { get; set; }
    }
}
