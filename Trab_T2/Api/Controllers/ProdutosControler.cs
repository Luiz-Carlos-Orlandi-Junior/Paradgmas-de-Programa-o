using Api.Database.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Mime;

namespace Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json,
              MediaTypeNames.Application.Xml)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class ProdutosControler : ControllerBase
    {
        private readonly ProdutoService _produtoService;

        public ProdutosControler(ProdutoService produtoService)
        {
         
            _produtoService = produtoService;
        }

        [HttpGet()]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        public ActionResult<List<Produto>> GetAll()
        {
            return Ok(_produtoService.GetAll());
        }

        [HttpGet(":codigo")]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        public ActionResult<Produto> GetByCodigo(int codigo)
        {
            try
            {
                var produto = _produtoService.GetById(codigo);

                return Ok(produto);
            }
            catch (NotFoundExcepition)
            {
                return NotFound("Produto não encontrado");  
            }

            catch (Exception e)
            {
                return BadRequest("Ocorreu um problema ao acessar produto" + 
                    e.Message);
            }
        }
    }
}
