using Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UserRepository : IBaseReposiroty<User>
    {
        public User GetByName(string name)
        {
            using (var context = new Context())
            {
                var item = context.User.FirstOrDefault(x => x.Login == name);
                return item;
            }
        }

        public User GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.User.FirstOrDefault(x => x.ID == id);
                return item;
            }
        }

        public List<User> GetList()
        {
            using (Context context = new Context())
            {
                return context.User.ToList();
            }
        }
        public User Update(User user)
        {
            using (var context = new Context())
            {
                context.User.Find(user);
                return null;
            }
        }

        public User Delete(long id)
        {
            using (var context = new Context())
            {
                context.User.Remove(GetById(id));
                context.SaveChanges();
                return null;
            }
        }

        public User Add(User user)
        {
            using (var context = new Context())
            {
                context.User.Add(user);
                context.SaveChanges();
                return null;
            }
        }

    }
}
