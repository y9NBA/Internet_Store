using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Infrastructure
{
    internal static class CustomMapper
    {
        public static CustomModel Map(Custom entity)
        {
            CustomModel viewModel = new CustomModel()
            {
                ID = entity.ID,
                Date_Order = entity.Date_Order,
                Status = entity.Status,
                Good = entity.Good,
                Total_Amount = entity.Total_Amount,
                Total_Price = entity.Total_Price,
                User = entity.User.ToList()
            };
            return viewModel;
        }
        public static List<CustomModel> Map(List<Custom> entities)
        {
            var viewModels = entities.Select(i => Map(i)).ToList();
            return viewModels;
        }
        public static Custom Map(CustomModel entity)
        {
            Custom model = new Custom()
            {
                ID = entity.ID,
                Date_Order = entity.Date_Order,
                Status = entity.Status,
                Good = entity.Good,
                Total_Amount = entity.Total_Amount,
                Total_Price = entity.Total_Price,
                User = entity.User
            };
            return model;
        }
        public static List<Custom> Map(List<CustomModel> entities)
        {
            var models = entities.Select(i => Map(i)).ToList();
            return models;
        }
    }
}
