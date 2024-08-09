using System;

namespace Consultorio.Interfaces
{
    public interface IReceita
    { 
        public string Medicamento { get; set; }
        public string Dosagem { get; set; }
        public string Data { get; set; }

        public void MostrarReceita();
    }
}
