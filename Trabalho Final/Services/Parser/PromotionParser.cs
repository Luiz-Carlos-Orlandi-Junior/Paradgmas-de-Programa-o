using Trabalho_Final.BaseDados.Models2;
using Trabalho_Final.DTO;

namespace Trabalho_Final.Services.Parser
{
    public static class PromotionParser
    {
        public static PromotionDTO ToDTO(this TbPromotion promotion)
        {
            if (promotion == null)
                return null;

            return new PromotionDTO
            {
                Id = promotion.Id,
                Startdate = promotion.Startdate,
                Enddate = promotion.Enddate,
                Promotiontype = promotion.Promotiontype,
                Productid = promotion.Productid,
                Value = promotion.Value
            };
        }

        public static TbPromotion ToEntity(this PromotionDTO promotionDTO)
        {
            if (promotionDTO == null)
                return null;

            return new TbPromotion
            {
                Id = promotionDTO.Id,
                Startdate = promotionDTO.Startdate,
                Enddate = promotionDTO.Enddate,
                Promotiontype = promotionDTO.Promotiontype,
                Productid = promotionDTO.Productid,
                Value = promotionDTO.Value
            };
        }
    }
}
