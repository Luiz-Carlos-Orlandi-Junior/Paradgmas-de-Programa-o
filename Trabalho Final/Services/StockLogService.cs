using System.Collections.Generic;
using System.Linq;
using Trabalho_Final.BaseDados.Models2;
using Trabalho_Final.DTO;
using Trabalho_Final.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using Trabalho_Final.BaseDados;

namespace Trabalho_Final.Services
{
    public class StockLogService
    {
        private readonly TfDbContext _context;

        public StockLogService(TfDbContext context)
        {
            _context = context;
        }

        public List<TbStockLog> Get()
        {
            return _context.TbStockLogs.Include(s => s.Product).ToList();
        }

        public TbStockLog GetById(int id)
        {
            var stockLog = _context.TbStockLogs.Include(s => s.Product).FirstOrDefault(s => s.Id == id);
            if (stockLog == null)
            {
                throw new NotFoundException("Stock log not found");
            }
            return stockLog;
        }

        public TbStockLog Insert(StockLogDTO dto)
        {
            var stockLog = new TbStockLog
            {
                Productid = dto.Productid,
                Qty = dto.Qty,
                Createdat = dto.Createdat
            };
            _context.TbStockLogs.Add(stockLog);
            _context.SaveChanges();
            return stockLog;
        }

        public TbStockLog Update(StockLogDTO dto, int id)
        {
            var stockLog = _context.TbStockLogs.Find(id);
            if (stockLog == null)
            {
                throw new NotFoundException("Stock log not found");
            }
            stockLog.Productid = dto.Productid;
            stockLog.Qty = dto.Qty;
            stockLog.Createdat = dto.Createdat;
            _context.TbStockLogs.Update(stockLog);
            _context.SaveChanges();
            return stockLog;
        }

        public void Delete(int id)
        {
            var stockLog = _context.TbStockLogs.Find(id);
            if (stockLog == null)
            {
                throw new NotFoundException("Stock log not found");
            }
            _context.TbStockLogs.Remove(stockLog);
            _context.SaveChanges();
        }

        public List<StockLogDTO> GetLogsByProduct(int productId)
        {
            return _context.TbStockLogs
                .Include(s => s.Product)
                .Where(s => s.Productid == productId)
                .OrderByDescending(s => s.Createdat)
                .Select(s => new StockLogDTO
                {
                    Id = s.Id,
                    Productid = s.Productid,
                    Barcode = s.Product.Barcode,
                    Description = s.Product.Description,
                    Qty = s.Qty,
                    Createdat = s.Createdat
                })
                .ToList();
        }
    }
}
