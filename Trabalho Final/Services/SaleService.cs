using System;
using System.Collections.Generic;
using System.Linq;
using Trabalho_Final.BaseDados.Models2;
using Trabalho_Final.DTO;
using Trabalho_Final.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using Trabalho_Final.BaseDados;

namespace Trabalho_Final.Services
{
    public class SaleService
    {
        private readonly TfDbContext _context;
        private readonly PromotionService _promotionService;
        public SaleService(TfDbContext context, PromotionService promotionService)
        {
            _context = context;
            _promotionService = promotionService;
        }
        public List<TbSale> Get()
        {
            return _context.TbSales.Include(s => s.Product).ToList();
        }
        public List<TbSale> GetByCode(string code)
        {
            var sales = _context.TbSales.Include(s => s.Product).Where(s => s.Code == code).ToList();
            if (sales == null || sales.Count == 0)
            {
                throw new NotFoundException("Sales not found");
            }
            return sales;
        }
        public TbSale Insert(SaleDTO dto)
        {
            var product = _context.TbProducts.Find(dto.Productid);
            if (product == null)
            {
                throw new NotFoundException("Produto não encontrado");
            }

            if (product.Stock < dto.Qty)
            {
                throw new InvalidOperationException("Estoque insuficiente");
            }
            var currentDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
            var activePromotions = _promotionService.GetPromotionsByProductAndEnd(dto.Productid, currentDate);
            decimal discount = CalculateDiscount(activePromotions, dto.Price, dto.Qty);

            var sale = new TbSale
            {
                Code = dto.Code,
                Createat = DateTime.SpecifyKind(dto.Createat, DateTimeKind.Unspecified),
                Productid = dto.Productid,
                Price = dto.Price,
                Qty = dto.Qty,
                Discount = discount
            };
            product.Stock -= dto.Qty;
            LogStockUpdate(dto.Productid, -dto.Qty);
            _context.TbSales.Add(sale);
            _context.SaveChanges();
            return sale;
        }
        private decimal CalculateDiscount(List<TbPromotion> promotions, decimal price, int qty)
        {
            decimal discount = 0;
            promotions = promotions.OrderBy(p => p.Promotiontype).ToList();
            foreach (var promo in promotions)
            {
                switch (promo.Promotiontype)
                {
                    case 0:
                        discount += (price * (promo.Value / 100));
                        break;
                    case 1:
                        discount += promo.Value;
                        break;
                }
            }
            return discount;
        }
        private void LogStockUpdate(int productId, int qty)
        {
            var product = _context.TbProducts.Find(productId);
            var log = new TbStockLog
            {
                Productid = productId,
                Barcode = product.Barcode,
                Qty = qty,
                Createdat = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified)
            };

            _context.TbStockLogs.Add(log);
            _context.SaveChanges();
        }
        public TbSale Update(SaleDTO dto, int id)
        {
            var sale = _context.TbSales.Find(id);
            if (sale == null)
            {
                throw new NotFoundException("Sale not found");
            }
            sale.Code = dto.Code;
            sale.Createat = DateTime.SpecifyKind(dto.Createat, DateTimeKind.Unspecified);
            sale.Productid = dto.Productid;
            sale.Price = dto.Price;
            sale.Qty = dto.Qty;
            sale.Discount = dto.Discount;
            _context.TbSales.Update(sale);
            _context.SaveChanges();
            return sale;
        }
        public void Delete(int id)
        {
            var sale = _context.TbSales.Find(id);
            if (sale == null)
            {
                throw new NotFoundException("Sale not found");
            }
            _context.TbSales.Remove(sale);
            _context.SaveChanges();
        }

        public List<SaleReportDTO> GetSalesReportByPeriod(DateTime startDate, DateTime endDate)
        {
            var sales = _context.TbSales
                .Include(s => s.Product)
                .Where(s => s.Createat >= startDate && s.Createat <= endDate)
                .OrderByDescending(s => s.Createat)
                .ToList();

            var report = sales
                .GroupBy(s => s.Code)
                .Select(g => new SaleReportDTO
                {
                    SaleCode = g.Key,
                    Sales = g.Select(s => new SaleDetailDTO
                    {
                        ProductDescription = s.Product.Description,
                        Price = s.Price,
                        Quantity = s.Qty,
                        SaleDate = s.Createat
                    }).ToList()
                }).ToList();
            return report;
        }
    }
    public class SaleReportDTO
    {
        public string SaleCode { get; set; }
        public List<SaleDetailDTO> Sales { get; set; }
    }

    public class SaleDetailDTO
    {
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
