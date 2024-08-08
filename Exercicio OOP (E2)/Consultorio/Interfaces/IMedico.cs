using System;


namespace Consultorio.Interfaces
{
    public interface IMedico : IPessoa
    {
        string Especializacao { get; set; }
        string Licensa { get; set; }
        void Assinar();
        void Diagnosticar();
    }
}
