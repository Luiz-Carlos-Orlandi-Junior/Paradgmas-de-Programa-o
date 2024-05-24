using System;
using System.Collections.Generic;
using System.Linq;
using Trab_TF.BaseDados.Models;
using Trab_TF.DataBase;
using Trab_TF.Services.DTOs;
using Trab_TF.Services.Exceptions;
using Trab_TF.Services.Parser;
using Trab_TF.Services.Validate;


namespace Trab_TF.Services
{
    public class ProductService
    {
        private readonly TfDbContext _dbContext;
        public ProductService(TfDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TbProduct Insert(ProductDTO dto)
        {
            if (!ProductsValidate.Execute(dto))
            {
                throw new InvalidEntityException("Invalido o  barcode ou barcode type.");
            }

            var entity = ProductParser.toEntity(dto);

            _dbContext.TbProducts.Add(entity);
            _dbContext.SaveChanges();

            if (entity.Stock != 0)
            {
                LogStockChange(entity.Id, entity.Stock, "Initial stock");
            }

            return entity;
        }

        public TbProduct Update(int id, ProductDTO dto)
        {
            var entity = _dbContext.TbProducts.Find(id);
            if (entity == null)
            {
                throw new NotFoundException("Product not found.");
            }

            entity.Description = dto.Description;
            entity.Barcode = dto.Barcode;
            entity.Barcodetype = dto.Barcodetype;
            entity.Price = dto.Price;
            entity.Costprice = dto.Costprice;

            _dbContext.SaveChanges();

            return entity;
        }

        public TbProduct GetByBarcode(string barcode)
        {
            var product = _dbContext.TbProducts.FirstOrDefault(p => p.Barcode == barcode);
            if (product == null)
            {
                throw new NotFoundException("Product not found.");
            }
            return product;
        }

        public IEnumerable<TbProduct> GetByDescription(string description)
        {
            var products = _dbContext.TbProducts.Where(p => p.Description.Contains(description)).ToList();
            if (!products.Any())
            {
                throw new NotFoundException("No products found matching the description.");
            }
            return products;
        }

        public void AdjustStock(int productId, int adjustment)
        {
            var product = _dbContext.TbProducts.Find(productId);
            if (product == null)
            {
                throw new NotFoundException("Product not found.");
            }

            product.Stock += adjustment;
            _dbContext.SaveChanges();

            LogStockChange(productId, adjustment, "Manual adjustment");
        }

        public void LogStockChange(int productId, int adjustment, string v)
        {
            var log = new TbStockLog
            {
                Productid = productId,
                Qty = adjustment,
                Createdat = DateTime.Now,
                //Reason = reason
            };

            _dbContext.TbStockLogs.Add(log);
            _dbContext.SaveChanges();
        }
    }
}
