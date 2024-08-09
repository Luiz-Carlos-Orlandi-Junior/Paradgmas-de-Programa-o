using System;
using Consultorio.Interfaces;
using Consultorio.Classes;
using System.Net.WebSockets;
using static System.Runtime.InteropServices.JavaScript.JSType;


var Medico = new CMedico();
    Medico.Nome = "Luiz";
    Medico.Especializacao = "Cardiologista";
    Medico.Licensa = "lic123";
    Medico.Sexo = "Masculino";
    Medico.CPF = "18636914252";

    var Enfermeira = new CEnfermeira();
    Enfermeira.Nome = "Alessandra";
    Enfermeira.Especializacao = "Emergencia";
    Enfermeira.Sexo = "Feminino";
    Enfermeira.CPF = "88744415962";

   var Paciente = new CPaciente();
   Paciente.Nome = "Felipe";
   Paciente.Sexo = "Masculino";
   Paciente.CPF = "452.547.474.74";
   Paciente.NumConvenio = "12345c";

   var Secretaria =  new CSecretaria();
   Secretaria.Nome = "Solange";
   Secretaria.CPF = "78554152325";
   Secretaria.Sexo = "Feminino";

   var Receita = new CReceita();
   Receita.Medicamento = "Ritalina";
   Receita.Dosagem = "1x ao dia";
   Receita.Data = "08/08/2024";

   var Consulta = new CConsulta();
   Consulta.Horario = "8:30";
   Consulta.Finalidade = "Indentificar causa dos sintomas relatados pelo paciente";
   Consulta.Local = "Centro Medico Santo Antônio";

Secretaria.MarcarConsulta();
    {
    Console.WriteLine($"Consulta:\n\nDr {Medico.Nome} de Especialização: {Medico.Especializacao}\nAtenderá o Paciente {Paciente.Nome} portador do CPF {Paciente.CPF}, " +
                   $"\nQue possui o Convenio de numero {Paciente.NumConvenio}\nA consulta ocorrerá no {Consulta.Local} ás {Consulta.Horario}\nCom finalidade de " +
                   $"{Consulta.Finalidade}");
}

Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

Receita.MostrarReceita();
{
    Console.WriteLine($"Receita:\n\nMédico: {Medico.Nome}\nPaciente: {Paciente.Nome}\nMedicamento: {Receita.Medicamento}\nDosagem: {Receita.Dosagem}\nData: {Receita.Data}");
    Medico.Assinar();
}

Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

Medico.Diagnosticar();
{
    Console.WriteLine($"Diagnostico:\n\nDr {Medico.Nome} chegou a conclusão apos consulta do paciente {Paciente.Nome}\nPortador do convenio {Paciente.NumConvenio}\nA conclusão foi que o paciente teria todos sintomas de um TDAH\n o medicamento será receitado, somente pelo diagnostico tambem do Neurologista");
}

Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

Console.WriteLine("Administração da medicação ao paciente\n\nA administração da medicação que irá ser passada ao paciente, será toda feita pela Enfermeira do Consultorio");

Enfermeira.AdministrarMedicacao();
{
    Console.WriteLine($"{Enfermeira.Nome} está administrando medicação, e auxliando o Dr {Medico.Nome} ");
}



