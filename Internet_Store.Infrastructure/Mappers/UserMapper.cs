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
                Login = entity.Login,
                Password = entity.Password
            };
            return viewModel;
        }
        public static List<UserModel> Map(List<User> entities)
        {
            var viewModels = entities.Select(i => Map(i)).ToList();
            return viewModels;
        }
    }
}
