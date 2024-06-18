using Trabalho_Final.BaseDados.Models2;
using Trabalho_Final.DTO;

namespace Trabalho_Final.Services.Parser
{
    public static class StockLogParser
    {
        public static StockLogDTO ToDTO(this TbStockLog stockLog)
        {
            if (stockLog == null)
                return null;

            return new StockLogDTO
            {
                Id = stockLog.Id,
                Productid = stockLog.Productid,
                Qty = stockLog.Qty,
                Createdat = stockLog.Createdat
            };
        }

        public static TbStockLog ToEntity(this StockLogDTO stockLogDTO)
        {
            if (stockLogDTO == null)
                return null;

            return new TbStockLog
            {
                Id = stockLogDTO.Id,
                Productid = stockLogDTO.Productid,
                Qty = stockLogDTO.Qty,
                Createdat = stockLogDTO.Createdat
            };
        }
    }
}
