using ApiWebDB.BaseDados.Models;
using ApiWebDB.BaseDados;
using ApiWebDB.Services.DTOs;
using ApiWebDB.Services.Parser;
using ApiWebDB.Services.Validate;
using APIWebDB.Services.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace APIWebDB.Services
{
    public class EnderecoService
    {

        private readonly ApiDbContext _dbContext;

        public EnderecoService(ApiDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public TbEndereco Insert(EnderecoDTO dto)
        {

            if (!EnderecoValidate.Execute(dto))
            {
                return null;
            }

            var entity = EnderecoParser.ToEntity(dto);

            _dbContext.Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public TbEndereco Put(EnderecoDTO dto, int id)
        {
            if (!EnderecoValidate.Execute(dto))
            {
                return null;
            }


            var entity = EnderecoParser.ToEntity(dto);

            var EnderecoById = GetById(id);
            EnderecoById.Cep = entity.Cep;
            EnderecoById.Logradouro = entity.Logradouro;
            EnderecoById.Numero = entity.Numero;
            EnderecoById.Complemento = entity.Complemento;
            EnderecoById.Bairro = entity.Bairro;
            EnderecoById.Cidade = entity.Cidade;
            EnderecoById.Uf = entity.Uf;
            EnderecoById.Clienteid = entity.Clienteid;
            EnderecoById.Status = entity.Status;

            _dbContext.Update(EnderecoById);
            _dbContext.SaveChanges();

            return EnderecoById;

        }

        public void Delete(int id)
        {
            var Endereco = GetById(id);

            if (Endereco == null)
            {
                throw new NotFoundException($"Entidade desejada não foi encontrada com o id: {id}");
            }
            _dbContext.Remove(Endereco);
            _dbContext.SaveChanges();

        }

        public TbEndereco Update(int id, EnderecoDTO dto)
        {
            var existEntity = GetById(id);
            if (existEntity == null)
            {
                throw new NotFoundException($"Endereco que possue o id {id} não foi encontrado");
            }

            var endereco = EnderecoParser.ToEntity(dto);

            existEntity.Cep = endereco.Cep;
            existEntity.Logradouro = endereco.Logradouro;
            existEntity.Numero = endereco.Numero;
            existEntity.Complemento = endereco.Complemento;
            existEntity.Bairro = endereco.Bairro;
            existEntity.Cidade = endereco.Cidade;
            existEntity.Uf = endereco.Uf;
            existEntity.Status = endereco.Status;

            _dbContext.Update(existEntity);
            _dbContext.SaveChanges();

            return existEntity;
        }

        public TbEndereco GetById(int id)
        {
            return _dbContext.TbEnderecos.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<TbEndereco> GetAll(int idCliente)
        {
            var existEntities = _dbContext.TbEnderecos.Where(e => e.Clienteid == idCliente).ToList();
            if (existEntities == null || existEntities.Count == 0)
            {
                throw new NotFoundException("Nenhum endereço foi encontrado para o cliente desejado");
            }
            return existEntities;
        }
    }
}