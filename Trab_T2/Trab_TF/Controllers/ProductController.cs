
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using Trab_TF.BaseDados.Models;
using Trab_TF.Services;
using Trab_TF.Services.DTOs;
using Trab_TF.Services.Exceptions;

namespace Trab_TF.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ProductService service, ILogger<ProductController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<TbProduct> Insert([FromBody] ProductDTO product)
        {
            try
            {
                var entity = _service.Insert(product);
                return Ok(entity);
            }
            catch (InvalidEntityException e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity(new { error = e.Message });
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(new { error = e.Message });
            }
        }

        [HttpPut("{id}")]
        public ActionResult<TbProduct> Update(int id, [FromBody] ProductDTO product)
        {
            try
            {
                var entity = _service.Update(id, product);
                return Ok(entity);
            }
            catch (NotFoundException e)
            {
                _logger.LogError(e.Message);
                return NotFound(new { error = e.Message });
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(new { error = e.Message });
            }
        }

        [HttpGet("{barcode}")]
        public ActionResult<TbProduct> GetByBarcode(string barcode)
        {
            try
            {
                var product = _service.GetByBarcode(barcode);
                return Ok(product);
            }
            catch (NotFoundException e)
            {
                _logger.LogError(e.Message);
                return NotFound(new { error = e.Message });
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(new { error = e.Message });
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<TbProduct>> GetByDescription([FromQuery] string description)
        {
            try
            {
                var products = _service.GetByDescription(description);
                return Ok(products);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(new { error = e.Message });
            }
        }

        [HttpPost("AdjustStock")]
        public ActionResult<TbProduct> AjustStock(ProductDTO product)
        {
            try
            {
                var entity = _service.Insert(product);
                return Ok(entity);
            }
            catch (InvalidEntityException e)
            {
                _logger.LogError(e.Message);
                return new ObjectResult(new { error = e.Message })
                {
                    StatusCode = 422
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(new { error = e.Message });
            }
        }
    }
}



