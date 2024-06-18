using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Trabalho_Final.DTO;
using Trabalho_Final.Services;

namespace Trabalho_Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly SaleService _saleService;

        public SalesController(SaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SaleDTO>> Get()
        {
            return Ok(_saleService.Get());
        }

        [HttpGet("{code}")]
        public ActionResult<SaleDTO> Get(string code)
        {
            return Ok(_saleService.GetByCode(code));
        }

        [HttpPost]
        public ActionResult<SaleDTO> Post([FromBody] SaleDTO dto)
        {
            var sale = _saleService.Insert(dto);
            return CreatedAtAction(nameof(Get), new { id = sale.Id }, sale);
        }

        [HttpPut("{id}")]
        public ActionResult<SaleDTO> Put(int id, [FromBody] SaleDTO dto)
        {
            var sale = _saleService.Update(dto, id);
            return Ok(sale);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _saleService.Delete(id);
            return NoContent();
        }

        [HttpGet("report")]
        public ActionResult<IEnumerable<SaleReportDTO>> GetSalesReportByPeriod([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var report = _saleService.GetSalesReportByPeriod(startDate, endDate);
            return Ok(report);
        }
    }
}
