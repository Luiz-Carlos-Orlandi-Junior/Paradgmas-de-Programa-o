using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ApiWebDB.DTO;
using TrabalhoFinal.Services;

namespace ApiWebDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockLogsController : ControllerBase
    {
        private readonly StockLogService _stockLogService;

        public StockLogsController(StockLogService stockLogService)
        {
            _stockLogService = stockLogService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StockLogDTO>> Get()
        {
            return Ok(_stockLogService.Get());
        }

        [HttpGet("{id}")]
        public ActionResult<StockLogDTO> Get(int id)
        {
            return Ok(_stockLogService.GetById(id));
        }

        [HttpPost]
        public ActionResult<StockLogDTO> Post([FromBody] StockLogDTO dto)
        {
            var stockLog = _stockLogService.Insert(dto);
            return CreatedAtAction(nameof(Get), new { id = stockLog.Id }, stockLog);
        }

        [HttpPut("{id}")]
        public ActionResult<StockLogDTO> Put(int id, [FromBody] StockLogDTO dto)
        {
            var stockLog = _stockLogService.Update(dto, id);
            return Ok(stockLog);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _stockLogService.Delete(id);
            return NoContent();
        }

        [HttpGet("product/{productId}")]
        public ActionResult<IEnumerable<StockLogDTO>> GetLogsByProduct(int productId)
        {
            var logs = _stockLogService.GetLogsByProduct(productId);
            return Ok(logs);
        }
    }
}
