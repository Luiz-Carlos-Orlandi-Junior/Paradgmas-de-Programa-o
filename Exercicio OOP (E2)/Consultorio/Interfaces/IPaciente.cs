using System;


namespace Consultorio.Interfaces
{
    public interface IPaciente : IPessoa
    {
        string NumConvenio { get; set; }
        
    }
}
