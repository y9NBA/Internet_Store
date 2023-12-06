using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class RoleRepository : IBaseReposiroty<Role>
    {
        public Role GetById(long id)
        {
            using (var context = new Context())
            {
                return context.Role.ToList().Where(i => i.ID == id).FirstOrDefault();
            }
        }
        public Role GetByName(string name)
        {
            using (var context = new Context())
            {
                return context.Role.ToList().Where(i => i.Name_Role == name).FirstOrDefault();
            }
        }
        public List<Role> GetList()
        {
            using(var context = new Context())
            {
                return context.Role.ToList();
            }
        }
        public Role Add(Role role)
        {
            return null;
        }
        public Role Update(Role role)
        {
            return null;
        }
        public Role Delete(long id)
        {
            return null;
        }
    }
}
