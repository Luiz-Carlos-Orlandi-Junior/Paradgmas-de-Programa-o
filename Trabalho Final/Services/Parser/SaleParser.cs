using Trabalho_Final.BaseDados.Models2;
using Trabalho_Final.DTO;

namespace Trabalho_Final.Services.Parser
{
    public static class SaleParser
    {
        public static SaleDTO ToDTO(this TbSale sale)
        {
            if (sale == null)
                return null;

            return new SaleDTO
            {
                Id = sale.Id,
                Code = sale.Code,
                Createat = sale.Createat,
                Productid = sale.Productid,
                Price = sale.Price,
                Qty = sale.Qty,
                Discount = sale.Discount
            };
        }

        public static TbSale ToEntity(this SaleDTO saleDTO)
        {
            if (saleDTO == null)
                return null;

            return new TbSale
            {
                Id = saleDTO.Id,
                Code = saleDTO.Code,
                Createat = saleDTO.Createat,
                Productid = saleDTO.Productid,
                Price = saleDTO.Price,
                Qty = saleDTO.Qty,
                Discount = saleDTO.Discount
            };
        }
    }
}
