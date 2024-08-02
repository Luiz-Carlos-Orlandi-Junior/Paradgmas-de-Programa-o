using System;
using E1;

var universitario = new Universidade.Universitario("Luiz");
universitario.Estudar();
universitario.Nome = "Carlos";
universitario.Estudar();
Console.WriteLine($"Nome do universitário: {universitario.Nome}");

var mochila = new Universidade.GuardarMateriais();
mochila.Finalidade();

var universidade = new E1.Universidade();
universidade.AbrirMochila();
universidade.AbrirMochila("Mochila Verde");

var patrimonio = new Universidade.Patrimonio
{
    Nome = "Biblioteca",
    Numeracao = "56818BILB1659"
};
patrimonio.ExibirPatrimonio();