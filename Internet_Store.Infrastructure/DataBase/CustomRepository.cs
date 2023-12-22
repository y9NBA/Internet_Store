using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class CustomRepository : IBaseReposiroty<Custom>
    {
        public List<Custom> GetByUser(UserModel userM)
        {
            using (var context = new Context())
            {
                var item = context.Custom.Where(x => x.User.ID == userM.ID).ToList();
                return (item);
            }
        }

        public Custom GetByName(string name)
        {
            return null;
        }

        public Custom GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.Custom.FirstOrDefault(x => x.ID == id);
                return (item);
            }
        }

        public List<Custom> GetList()
        {
            using (Context context = new Context())
            {
                var item = context.Custom.Include("Good")
                                         .Include("Status")
                                         .Include("Good.User")
                                         .Include("Good.Type").ToList();
                return item;
            }
        }

        public Custom Update(Custom Custom)
        {
            using (var context = new Context())
            {
                int countG = context.Custom.ToList().Count;

                context.Custom.AddOrUpdate((Custom));

                if (context.Custom.ToList().Count != countG)
                {
                    Delete(context.Custom.Last().ID);
                    return null;
                }
                else
                {
                    context.SaveChanges();
                    return new Custom();
                }
            }
        }

        public Custom Delete(long id)
        {
            using (var context = new Context())
            {
                if (context.Custom.Remove(context.Custom.Find(id)) == null)
                {
                    return null;
                }
                else
                {
                    context.SaveChanges();
                    return new Custom();
                }
            }
        }

        public Custom Add(Custom Custom)
        {
            using (var context = new Context())
            {
                if (context.Custom.Add((Custom)) == null)
                {
                    return null;
                }
                else
                {
                    context.SaveChanges();
                    return new Custom();
                }
            }
        }
    }
}
