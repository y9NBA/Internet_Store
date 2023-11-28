using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class GoodRepository : IBaseReposiroty<GoodModel>
    {
        public GoodModel GetByName(string name)
        {
            using (var context = new Context())
            {
                var item = context.Good.FirstOrDefault(x => x.Name == name);
                return GoodMapper.Map(item);
            }
        }

        public GoodModel GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.Good.FirstOrDefault(x => x.ID == id);
                return GoodMapper.Map(item);
            }
        }

        public List<GoodModel> GetList()
        {
            using (Context context = new Context())
            {
                return GoodMapper.Map(context.Good.ToList());
            }
        }
        public GoodModel Update(GoodModel Good)
        {
            using (var context = new Context())
            {
                int countG = context.Good.ToList().Count;

                context.Good.AddOrUpdate(GoodMapper.Map(Good));

                if (context.Good.ToList().Count != countG)
                {
                    Delete(context.Good.Last().ID);
                    return null;
                }
                else
                {
                    context.SaveChanges();
                    return new GoodModel();
                }
            }
        }

        public GoodModel Delete(long id)
        {
            using (var context = new Context())
            {
                if (context.Good.Remove(context.Good.Find(id)) == null)
                {
                    return null;
                }
                else
                {
                    context.SaveChanges();
                    return new GoodModel();
                }
            }
        }

        public GoodModel Add(GoodModel GoodModel)
        {
            using (var context = new Context())
            {
                Good Good = GoodMapper.Map(GoodModel);

                if (context.Good.Add(Good) == null)
                {
                    return null;
                }
                else
                {
                    context.SaveChanges();
                    return new GoodModel();
                }
            }
        }
    }
}
