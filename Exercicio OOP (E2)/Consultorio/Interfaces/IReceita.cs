using System;

namespace Consultorio.Interfaces
{
    public interface IReceita
    {
        IMedico Medico { get; set; }
        IPaciente Paciente { get; set; }
        string Medicamento { get; set; }
        string Dosagem { get; set; }
        DateTime Data { get; set; }

        void MostrarReceita();
    }
}
