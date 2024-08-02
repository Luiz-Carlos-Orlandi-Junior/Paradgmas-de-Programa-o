using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Trabalho_Final.DTO;
using Trabalho_Final.Services;
using Trabalho_Final.Services.Exceptions;
using Trabalho_Final.BaseDados.Models2;


namespace Trabalho_Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TbProduct>> Get()
        {
            try
            {
                return Ok(_productService.Get());
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<TbProduct> Get(int id)
        {
            try
            {
                return Ok(_productService.GetById(id));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("barcode/{barcode}")]
        public ActionResult<TbProduct> GetByBarcode(string barcode)
        {
            try
            {
                return Ok(_productService.GetByBarcode(barcode));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("description/{description}")]
        public ActionResult<IEnumerable<TbProduct>> GetByDescription(string description)
        {
            try
            {
                return Ok(_productService.GetByDescription(description));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<TbProduct> Post([FromBody] ProductDTO dto)
        {
            var product = _productService.Insert(dto);
            if (product == null)
                return BadRequest("Invalid product data");

            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public ActionResult<TbProduct> Put(int id, [FromBody] ProductDTO dto)
        {
            try
            {
                var product = _productService.Update(dto, id);
                return Ok(product);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}/adjust-stock")]
        public ActionResult AdjustStock(int id, [FromBody] int quantity)
        {
            try
            {
                _productService.AdjustStock(id, quantity);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _productService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
