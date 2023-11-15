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

        public User GetById(int id)
        {
            return null;
        }
        //public User GetById(int id)
        //{
        //    using (var context = new Context())
        //    {
        //        var item = context.User.FirstOrDefault(x => x.id == id);
        //        return item;
        //    }
        //}

        public List<User> GetList()
        {
            using (Context context = new Context())
            {
                return context.User.ToList();
            }
        }

    }
}
