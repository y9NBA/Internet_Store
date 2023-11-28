using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    internal static class ReviewMapper
    {
        public static ReviewModel Map(Review entity)
        {
            ReviewModel viewModel = new ReviewModel()
            {
                ID = entity.ID,
                Date = entity.Date,
                Value = entity.Value,
                Description = entity.Description,
                CustomerID = entity.CustomerID,
                User = entity.User,
                Good = entity.Good.ToList()
            };
            return viewModel;
        }
        public static List<ReviewModel> Map(List<Review> entities)
        {
            var viewModels = entities.Select(i => Map(i)).ToList();
            return viewModels;
        }
        public static Review Map(ReviewModel entity)
        {
            Review model = new Review()
            {
                ID = entity.ID,
                Date = entity.Date,
                Value = entity.Value,
                Description = entity.Description,
                CustomerID = entity.CustomerID,
                User = entity.User,
                Good = entity.Good
            };
            return model;
        }
        public static List<Review> Map(List<ReviewModel> entities)
        {
            var models = entities.Select(i => Map(i)).ToList();
            return models;
        }
    }
}
    }
}
