using System;
using Trab_TF.BaseDados.Models;
using Trab_TF.Services.DTOs;

namespace Trab_TF.Services.Parser
{
    public class ProductParser
    {
        public static TbProduct toEntity(ProductDTO dto)
        {

            return new TbProduct
            {
                //   Id = dto.Id,
                Description = dto.Description,
                Barcode = dto.Barcode,
                Barcodetype = dto.Barcodetype,
                Stock = dto.Stock,
                Price = dto.Price,
                Costprice = dto.Costprice,
            };
        }
    }
}
