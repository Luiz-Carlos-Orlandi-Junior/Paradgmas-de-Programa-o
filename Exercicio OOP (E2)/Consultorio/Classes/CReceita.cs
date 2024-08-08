using System;
using Consultorio.Interfaces;

namespace Consultorio.Classes
{
    public class CReceita : IReceita
    {
        public IMedico Medico { get; set; }
        public IPaciente Paciente { get; set; }
        public string Medicamento { get; set; }
        public string Dosagem { get; set; }
        public DateTime Data { get; set; }

        // Construtor da classe Receita
        public CReceita(IMedico medico, IPaciente paciente, string medicamento, string dosagem)
        {
            Medico = medico;
            Paciente = paciente;
            Medicamento = medicamento;
            Dosagem = dosagem;
    
        }

        // Implementação do método MostrarReceita
        public void MostrarReceita()
        {
            Console.WriteLine($"Receita:\nMédico: {Medico.Nome}\nPaciente: {Paciente.Nome}\nMedicamento: {Medicamento}\nDosagem: {Dosagem}\nData: {Data}");
        }
    }
}
