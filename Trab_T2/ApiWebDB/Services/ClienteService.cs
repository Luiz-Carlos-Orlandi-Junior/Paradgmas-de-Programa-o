using ApiWebDB.BaseDados;
using ApiWebDB.BaseDados.Models;
using ApiWebDB.Services.Dtos;
using ApiWebDB.Services.DTOs;
using ApiWebDB.Services.Parser;
using APIWebDB.Services.Exceptions;
using APIWebDB.Services.Validate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiWebDB.Services
{
    public class ClienteService
    {

        private readonly ApiDbContext _dbContext;
        public  ClienteService(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TbCliente Insert(ClienteDTO dto)
        {

            if (!ClienteValidate.Execute(dto))
            {
                return null;
            }

            var entity = ClienteParser.toEntity(dto);

            _dbContext.Add(entity);
            _dbContext.SaveChanges();

            return entity;

        }

        public TbCliente Put(ClienteDTO dto, int id)
        {
            if (!ClienteValidate.Execute(dto))
            {
                return null;
            }

            var entity = ClienteParser.toEntity(dto);

            var ClienteById = GetById(id);
            ClienteById.Nome = entity.Nome;
            ClienteById.Nascimento = entity.Nascimento;
            ClienteById.Telefone = entity.Telefone;
            ClienteById.Documento = entity.Documento;
            ClienteById.Tipodoc = entity.Tipodoc;
            ClienteById.Alteradoem = DateTime.Now;

            _dbContext.Update(ClienteById);
            _dbContext.SaveChanges();

            return ClienteById;

        }

        public void Delete(int id)
        {
            var Cliente = GetById(id);

            if (Cliente == null)
            {
                throw new NotFoundException($"Entidade não encontrada com o id: {id}");
            }
            _dbContext.Remove(Cliente);
            _dbContext.SaveChanges();

        }

        public TbCliente Update(TbCliente entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public TbCliente GetById(int id)
        {
            return _dbContext.TbClientes.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<TbCliente> GetAll()
        {
            var existEntity = _dbContext.TbClientes.ToList();
            if (existEntity == null || existEntity.Count == 0)
            {
                throw new NotFoundException("Nenhum registro foi  encontrado");
            }
            return existEntity;
        }
    }
}
