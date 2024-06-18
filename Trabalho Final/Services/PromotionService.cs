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
    public class PromotionService
    {
        private readonly TfDbContext _context;

        public PromotionService(TfDbContext context)
        {
            _context = context;
        }

        public List<TbPromotion> Get()
        {
            return _context.TbPromotions.Include(p => p.Product).ToList();
        }

        public TbPromotion GetById(int id)
        {
            var promotion = _context.TbPromotions.Include(p => p.Product).FirstOrDefault(p => p.Id == id);
            if (promotion == null)
            {
                throw new NotFoundException("Promotion not found");
            }
            return promotion;
        }

        public List<TbPromotion> GetPromotionsByProductAndPeriod(int productId, DateTime startDate, DateTime endDate)
        {
            var promotions =  _context.TbPromotions.Include(p => p.Product).Where(p => p.Productid == productId && p.Startdate >= startDate && p.Enddate <= endDate).ToList();
            return promotions;
        }
        public List<TbPromotion> GetPromotionsByProductAndEnd(int productId, DateTime endDate)
        {
            var promotions =  _context.TbPromotions.Include(p => p.Product).Where(p => p.Productid == productId && p.Enddate >= endDate).ToList();
            return promotions;
        }

        public TbPromotion Insert(PromotionDTO dto)
        {
            var promotion = new TbPromotion
            {
                Startdate = dto.Startdate,
                Enddate = dto.Enddate,
                Promotiontype = dto.Promotiontype,
                Productid = dto.Productid,
                Value = dto.Value
            };
            _context.TbPromotions.Add(promotion);
            _context.SaveChanges();
            return promotion;
        }

        public TbPromotion Update(PromotionDTO dto, int id)
        {
            var promotion = _context.TbPromotions.Find(id);
            if (promotion == null)
            {
                throw new NotFoundException("Promotion not found");
            }
            promotion.Startdate = dto.Startdate;
            promotion.Enddate = dto.Enddate;
            promotion.Promotiontype = dto.Promotiontype;
            promotion.Productid = dto.Productid;
            promotion.Value = dto.Value;
            _context.TbPromotions.Update(promotion);
            _context.SaveChanges();
            return promotion;
        }

        public void Delete(int id)
        {
            var promotion = _context.TbPromotions.Find(id);
            if (promotion == null)
            {
                throw new NotFoundException("Promotion not found");
            }
            _context.TbPromotions.Remove(promotion);
            _context.SaveChanges();
        }
    }
}
