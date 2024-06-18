using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Trabalho_Final.DTO;
using Trabalho_Final.Services;
using Trabalho_Final.BaseDados.Models2;
using Trabalho_Final.Services.Exceptions;

namespace Trabalho_Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionsController : ControllerBase
    {
        private readonly PromotionService _promotionService;

        public PromotionsController(PromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TbPromotion>> Get()
        {
            try
            {
                return Ok(_promotionService.Get());
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<TbPromotion> Get(int id)
        {
            try
            {
                return Ok(_promotionService.GetById(id));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("product/{productId}/period")]
        public ActionResult<IEnumerable<TbPromotion>> GetPromotionsByProductAndPeriod(int productId, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            try
            {
                return Ok(_promotionService.GetPromotionsByProductAndPeriod(productId, startDate, endDate));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<TbPromotion> Post([FromBody] PromotionDTO dto)
        {
            var promotion = _promotionService.Insert(dto);
            if (promotion == null)
                return BadRequest("Invalid promotion data");

            return CreatedAtAction(nameof(Get), new { id = promotion.Id }, promotion);
        }

        [HttpPut("{id}")]
        public ActionResult<TbPromotion> Put(int id, [FromBody] PromotionDTO dto)
        {
            try
            {
                var promotion = _promotionService.Update(dto, id);
                return Ok(promotion);
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
                _promotionService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
