using System;
using Consultorio.Interfaces;

namespace Consultorio.Classes
{
    public class CReceita : IReceita
    {
        private string _medicamento;
        private string _dosagem;
        private string _data;

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

        // Implementação do método MostrarReceita
        public void MostrarReceita()
        {

        }
    }
}
