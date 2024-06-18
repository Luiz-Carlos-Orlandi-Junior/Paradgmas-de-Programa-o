using System;
using System.Collections.Generic;
using System.Linq;
using Trabalho_Final.BaseDados.Models2;
using Trabalho_Final.DTO;
using Trabalho_Final.Services.Exceptions;
using Trabalho_Final.Services.Validate;
using Microsoft.EntityFrameworkCore;
using Trabalho_Final.BaseDados;


namespace Trabalho_Final.Services
{
    public class ProductService
    {
        private readonly TfDbContext _context;

        public ProductService(TfDbContext context)
        {
            _context = context;
        }

        public List<TbProduct> Get()
        {
            return _context.TbProducts.ToList();
        }

        public TbProduct GetById(int id)
        {
            var product = _context.TbProducts.Find(id);
            if (product == null)
            {
                throw new NotFoundException("Product not found");
            }
            return product;
        }

        public TbProduct GetByBarcode(string barcode)
        {
            var product = _context.TbProducts.FirstOrDefault(p => p.Barcode == barcode);
            if (product == null)
            {
                throw new NotFoundException("Product not found");
            }
            return product;
        }

        public List<TbProduct> GetByDescription(string description)
        {
            return _context.TbProducts
                .Where(p => EF.Functions.Like(p.Description, $"%{description}%"))
                .ToList();
        }

        public TbProduct Insert(ProductDTO dto)
        {
            var product = new TbProduct
            {
                Description = dto.Description,
                Barcode = dto.Barcode,
                Barcodetype = dto.Barcodetype,
                Stock = dto.Stock,
                Price = dto.Price,
                Costprice = dto.Costprice
            };
            ProductValidator.Validate(product);
            _context.TbProducts.Add(product);
            _context.SaveChanges();

            // Log the stock change
            InsertStockLog(product.Id, product.Stock);

            return product;
        }

        public TbProduct Update(ProductDTO dto, int id)
        {
            var product = _context.TbProducts.Find(id);
            if (product == null)
            {
                throw new NotFoundException("Product not found");
            }
            product.Description = dto.Description;
            product.Barcode = dto.Barcode;
            product.Barcodetype = dto.Barcodetype;
            product.Price = dto.Price;
            product.Costprice = dto.Costprice;
            _context.TbProducts.Update(product);
            _context.SaveChanges();
            return product;
        }

        public void AdjustStock(int productId, int quantity)
        {
            var product = _context.TbProducts.Find(productId);
            if (product == null)
            {
                throw new NotFoundException("Product not found");
            }
            product.Stock += quantity;
            _context.TbProducts.Update(product);
            _context.SaveChanges();

            // Log the stock change
            InsertStockLog(product.Id, quantity);
        }

        private void InsertStockLog(int productId, int quantity)
        {
            var stockLog = new TbStockLog
            {
                Productid = productId,
                Qty = quantity,
                Createdat = DateTime.Now
            };
            _context.TbStockLogs.Add(stockLog);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _context.TbProducts.Find(id);
            if (product == null)
            {
                throw new NotFoundException("Product not found");
            }
            _context.TbProducts.Remove(product);
            _context.SaveChanges();
        }
    }
}
