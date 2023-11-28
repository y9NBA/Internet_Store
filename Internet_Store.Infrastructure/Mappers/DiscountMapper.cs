using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    internal static class DiscountMapper
    {
        public static DiscountModel Map(Discount entity)
        {
            DiscountModel viewModel = new DiscountModel()
            {
                ID = entity.ID,
                Name_Discount = entity.Name_Discount,
                Size = entity.Size,
                Person = entity.Person.ToList()
            };
            return viewModel;
        }
        public static List<DiscountModel> Map(List<Discount> entities)
        {
            var viewModels = entities.Select(i => Map(i)).ToList();
            return viewModels;
        }
        public static Discount Map(DiscountModel entity)
        {
            Discount model = new Discount()
            {
                ID = entity.ID,
                Name_Discount = entity.Name_Discount,
                Size = entity.Size,
                Person = entity.Person.ToList()
            };
            return model;
        }
        public static List<Discount> Map(List<DiscountModel> entities)
        {
            var models = entities.Select(i => Map(i)).ToList();
            return models;
        }
    }
}
