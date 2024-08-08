using System;


namespace Consultorio.Interfaces
{
    public interface IMedico : IPessoa
    { 
        
        public string Especializacao {  get; set; }
        public string Licensa {  get; set; }
        public void Assinar();
        public void Diagnosticar();
    }
}
