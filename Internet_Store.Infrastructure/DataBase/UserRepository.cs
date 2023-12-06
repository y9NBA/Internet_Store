using Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UserRepository : IBaseReposiroty<UserModel>
    {
        public UserModel GetByName(string name)
        {
            using (var context = new Context())
            {
                var item = context.User.FirstOrDefault(x => x.Login == name);
                if(item == null)
                {
                    return null;
                }
                else
                {
                    return UserMapper.Map(item);
                }
            }
        }

        public UserModel GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.User.FirstOrDefault(x => x.ID == id);
                return UserMapper.Map(item);
            }
        }

        public List<UserModel> GetList()
        {
            using (Context context = new Context())
            {
                return UserMapper.Map(context.User.ToList());
            }
        }
        public UserModel Update(UserModel user)
        {
            using (var context = new Context())
            {
                int countP = context.Person.ToList().Count;
                int countU = context.User.ToList().Count;

                context.Person.AddOrUpdate(PersonMapper.Map(user.Person));
                context.User.AddOrUpdate(UserMapper.Map(user));

                if (context.Person.ToList().Count != countP && context.User.ToList().Count != countU)
                {
                    Delete(context.User.Last().ID);
                    return null;
                }
                else
                {
                    context.SaveChanges();
                    return new UserModel();
                }
            }
        }

        public UserModel Delete(long id)
        {
            using (var context = new Context())
            {
                if (context.User.Remove(context.User.Find(id)) == null)
                {
                    return null;
                }
                else
                {
                    context.SaveChanges();
                    return new UserModel();
                }
            }
        }

        public UserModel Add(UserModel userModel)
        {
            using (var context = new Context())
            {
                User user = UserMapper.Map(userModel);

                if (context.User.Add(user) == null)
                {
                    return null;
                }
                else
                {
                    context.SaveChanges();
                    return new UserModel();
                }
            }
        }

    }
}
