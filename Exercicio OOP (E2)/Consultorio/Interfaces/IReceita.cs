using System;

namespace Consultorio.Interfaces
{
    public interface IReceita
    {
        public IMedico Medico { get; set; }
        public IPaciente Paciente { get; set; }
        public string Medicamento { get; set; }
        public string Dosagem { get; set; }
        public string Data { get; set; }

        public void MostrarReceita();
    }
}
