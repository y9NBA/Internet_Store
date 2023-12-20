using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class TypeRepository : IBaseReposiroty<Type>
    {
        public Type GetById(long id)
        {
            using(var context = new Context()) 
            {
                return context.Type.Where(i => i.ID == id).FirstOrDefault();
            }
        }

        public Type GetByName(string name)
        {
            using (var context = new Context())
            {
                return context.Type.Where(i => i.Name_Type == name).FirstOrDefault();
            }
        }

        public List<Type> GetList() 
        {
            using(var context = new Context())
            {
                return context.Type.ToList();
            }
        }
        
        public Type Add(Type type)
        {
            return null;
        }

        public Type Update(Type type)
        {
            return null;
        }

        public Type Delete(long id)
        {
            return null;
        }
    }
}
