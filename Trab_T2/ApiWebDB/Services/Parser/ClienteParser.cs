using ApiWebDB.BaseDados.Models;
using ApiWebDB.Services.Dtos;
using System;

namespace ApiWebDB.Services.Parser
{
    public static class ClienteParser
    {
        public static TbCliente toEntity(ClienteDTO dto)
        { 
            var time = new TimeOnly(0, 0);
            var nascimento = new DateTime(
                (DateOnly)dto.Nascimento, time);

            return new TbCliente
            {
                Nascimento = nascimento,
                Nome = dto.Nome,
                Telefone = dto.Telefone,
                Tipodoc = dto.Tipodoc,
                Documento = dto.Documento,
                Criadoem = System.DateTime.Now,
                Alteradoem = System.DateTime.Now,
            };
        }

        internal static void UpdateEntityFromDTO(ClienteDTO cliente, object existingEntity)
        {
            throw new NotImplementedException();
        }
    }
}
