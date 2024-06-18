using Trabalho_Final.BaseDados.Models2;
using Trabalho_Final.DTO;

namespace Trabalho_Final.Services.Parser
{
    public static class ProductParser
    {
        public static ProductDTO ToDTO(this TbProduct product)
        {
            if (product == null)
                return null;

            return new ProductDTO
            {
                Id = product.Id,
                Description = product.Description,
                Barcode = product.Barcode,
                Barcodetype = product.Barcodetype,
                Stock = product.Stock,
                Price = product.Price,
                Costprice = product.Costprice
            };
        }

        public static TbProduct ToEntity(this ProductDTO productDTO)
        {
            if (productDTO == null)
                return null;

            return new TbProduct
            {
                Id = productDTO.Id,
                Description = productDTO.Description,
                Barcode = productDTO.Barcode,
                Barcodetype = productDTO.Barcodetype,
                Stock = productDTO.Stock,
                Price = productDTO.Price,
                Costprice = productDTO.Costprice
            };
        }
    }
}
