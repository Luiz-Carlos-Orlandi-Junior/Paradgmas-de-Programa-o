using System;
using Consultorio.Interfaces;

namespace Consultorio.Classes
{
    public class CReceita : IReceita
    {
        private string _medicamento;
        private string _dosagem;
        private string _data;
        private IMedico _medico;
        private IPaciente _paciente;
        public IMedico Medico
        {
            get { return _medico; }
            set { _medico = value; }
        }
        public IPaciente Paciente
        {
            get { return _paciente; }
            set { _paciente = value; }
        }

        public string Medicamento
        {
            get { return _medicamento; }
            set { _medicamento = value; }
        }
        public string Dosagem
        {
            get { return _dosagem; }
            set { _dosagem = value; }
        }

        public string Data
        {
            get { return _data; }
            set { _data = value; }
        }

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
