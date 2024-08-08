using System;


namespace Consultorio.Interfaces
{
    
        public interface IEnfermeira : IPessoa
        {
            string RegistroEnfermeira { get; set; }
            string Setor { get; set; }
           
            void AdministrarMedicacao();
        }
   
}
