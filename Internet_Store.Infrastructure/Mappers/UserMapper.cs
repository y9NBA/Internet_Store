using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class UserMapper
    {
        public static UserModel Map(User entity)
        {
            UserModel viewModel = new UserModel()
            {
                ID = entity.ID,
                Login = entity.Login,
                Password = entity.Password,
                RoleID = entity.RoleID,
                Role = entity.Role,
                Person = PersonMapper.Map(entity.Person),
                Goods = entity.Good.ToList(),
                Reviews = entity.Review.ToList(),
                Customs = entity.Custom.ToList()
            };
            return viewModel;
        }
        public static List<UserModel> Map(List<User> entities)
        {
            var viewModels = entities.Select(i => Map(i)).ToList();
            return viewModels;
        }

        public static User Map(UserModel entity)
        {
            User model = new User()
            {
                ID = entity.ID,
                Login = entity.Login,
                Password = entity.Password,
                RoleID = entity.RoleID,
                Role = entity.Role,
                Person = PersonMapper.Map(entity.Person),
                Good = entity.Goods,
                Review = entity.Reviews,
                Custom = entity.Customs
            };
            return model;
        }
        public static List<User> Map(List<UserModel> entities)
        {
            var models = entities.Select(i => Map(i)).ToList();
            return models;
        }
    }
}
