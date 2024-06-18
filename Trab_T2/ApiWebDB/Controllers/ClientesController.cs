using ApiWebDB.BaseDados.Models;
using ApiWebDB.Services.Dtos;
using ApiWebDB.Services.Parser;
using ApiWebDB.Services;
using APIWebDB.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Logging;

namespace APIWebDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {

        private readonly ClienteService _service;
        private readonly ILogger<ClientesController> _logger;
        public ClientesController(ClienteService service, 
            ILogger<ClientesController> logger)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost()]
        public ActionResult<TbCliente> Insert(ClienteDTO cliente)
        {
            try
            {
                var entity = _service.Insert(cliente);
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

        [HttpPut("{id}")]
        public ActionResult<TbCliente> Update(int id, ClienteDTO cliente)
        {
            try
            {
                var existingEntity = _service.GetById(id);
                if (existingEntity == null)
                {
                    return NotFound();
                }

                ClienteParser.UpdateEntityFromDTO(cliente, existingEntity);

                var updatedEntity = _service.Update(existingEntity);
                return Ok(updatedEntity);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
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
            catch(Exception E)
            {
                return new ObjectResult(new { error = E.Message })
                {
                    StatusCode = 500
                };
            }
        }

        [HttpGet("{id}")]
        public ActionResult<TbCliente> GetById(int id)
        {
            try
            {
                var entity = _service.GetById(id);
                   return Ok(entity);
            }
            catch (NotFoundException E)
            {
                _logger.LogError(E.Message);
                   return NotFound(E.Message);
            }
            catch (System.Exception e)
            {
                _logger.LogError(e.Message);
                    return new ObjectResult(new { error = e.Message })
                    {
                    StatusCode = 500
                    };
            }
        }
        /// <summary>
        /// Rota das consultas de todos os clientes cadastrados. 
        /// </summary>
        /// <returns>Retorna a lista de clientes cadastrados</returns>
        /// <response code="500">Erro interno de servidor</response>
        [HttpGet()]
        public ActionResult<TbCliente> GetAll()
        {
            try
            {
                var entity = _service.GetAll();
                return Ok(entity);
            }
            catch (NotFoundException E)
            {
                _logger.LogError(E.Message);
                return NotFound(E.Message);
            }
            catch (System.Exception e)
            {
                _logger.LogError(e.Message);
                return new ObjectResult(new { error = e.Message })
                {
                    StatusCode = 500
                };
            }
        }

    }
}
