using System;


namespace Consultorio.Interfaces
{
    public interface IPaciente : IPessoa
    {
        public string NumConvenio { get; set; }
        
    }
}
