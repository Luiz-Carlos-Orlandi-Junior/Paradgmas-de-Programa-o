using ApiWebDB.BaseDados.Models;
using ApiWebDB.Services.DTOs;
using ApiWebDB.Services.Parser;
using APIWebDB.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Logging;
using APIWebDB.Services;


namespace ApiWebDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly EnderecoService _service;
        private readonly ILogger<EnderecoController> _logger;
        public EnderecoController(EnderecoService service,
            ILogger<EnderecoController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Rota da insercao de novos enderecos
        /// </summary>
        ///  <param name="enderecoDTO">json dos dados que vao ser atualizados.  
        ///     Obrigatorios: CEP, Logradouro, Numero, Bairro, Cidade, Clienteid, Status (0 - inativo1 - ativo)
        /// </param>
        /// <returns>Retorna o endereco que foi inserido</returns>
        /// <response code="422">Os campos obrigatórios não enviados para a inserir</response>
        
        [HttpPost()]
        public ActionResult<TbEndereco> Insert(EnderecoDTO enderecoDTO)
        {
            try
            {
                var entity = _service.Insert(enderecoDTO);
                return Ok(entity);
            }
            catch (InvalidEntityException E)
            {
                _logger.LogError(E.Message);

                return new ObjectResult(new { error = E.Message })
                {
                    StatusCode = 422
                };

            }
            catch (Exception E)
            {

                return BadRequest(E.Message);
            }

        }

        [HttpDelete("{id}")]
        public ActionResult<TbCliente> Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return NoContent();
            }
            catch (NotFoundException E)
            {
                return NotFound(E.Message);
            }
            catch (Exception E)
            {
                return new ObjectResult(new { error = E.Message })
                {
                    StatusCode = 500
                };
            }
        }

        [HttpGet("/getById/{id}")]
        public ActionResult<TbCliente> GetById(int id)
        {
            try
            {
                var entity = _service.GetById(id);
                return Ok(entity);
            }
            catch (NotFoundException E)
            {
                return NotFound(E.Message);
            }
            catch (System.Exception e)
            {
                return new ObjectResult(new { error = e.Message })
                {
                    StatusCode = 500
                };
            }
        }
        [HttpGet("/getAll/{id}")]
        public ActionResult<TbCliente> GetAll(int id)
        {
            try
            {
                var entity = _service.GetAll(id);
                return Ok(entity);
            }
            catch (NotFoundException E)
            {
                return NotFound(E.Message);
            }
            catch (System.Exception e)
            {
                return new ObjectResult(new { error = e.Message })
                {
                    StatusCode = 500
                };
            }
        }

    }
}
