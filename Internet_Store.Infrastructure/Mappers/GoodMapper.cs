using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    internal static class GoodMapper
    {
        public static GoodModel Map(Good entity)
        {
            GoodModel viewModel = new GoodModel()
            {
                ID = entity.ID,
                Name = entity.Name,
                Description = entity.Description,
                Amount = entity.Amount,
                Price = entity.Price,
                TypeID = entity.TypeID,
                Customs = entity.Custom.ToList(),
                Type = entity.Type,
                Reviews = entity.Review.ToList(),
                Seller = entity.User
            };
            return viewModel;
        }
        public static List<GoodModel> Map(List<Good> entities)
        {
            var viewModels = entities.Select(i => Map(i)).ToList();
            return viewModels;
        }
        public static Good Map(GoodModel entity)
        {
            Good model = new Good()
            {
                ID = entity.ID,
                Name = entity.Name,
                Description = entity.Description,
                Amount = entity.Amount,
                Price = entity.Price,
                TypeID = entity.TypeID,
                Custom = entity.Customs,
                Type = entity.Type,
                Review = entity.Reviews,
                User = entity.Seller
            };
            return model;
        }
        public static List<Good> Map(List<GoodModel> entities)
        {
            var models = entities.Select(i => Map(i)).ToList();
            return models;
        }
    }
}
