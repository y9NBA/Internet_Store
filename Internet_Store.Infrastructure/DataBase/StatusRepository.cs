using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class StatusRepository : IBaseReposiroty<Status>
    {
        public Status GetById(long id)
        {
            using (var context = new Context())
            {
                return context.Status.Where(i => i.ID == id).FirstOrDefault();
            }
        }

        public Status GetByName(string name)
        {
            using (var context = new Context())
            {
                return context.Status.Where(i => i.Name_Status == name).FirstOrDefault();
            }
        }

        public List<Status> GetList()
        {
            using (var context = new Context())
            {
                return context.Status.ToList();
            }
        }

        public Status Add(Status Status)
        {
            return null;
        }

        public Status Update(Status Status)
        {
            return null;
        }

        public Status Delete(long id)
        {
            return null;
        }
    }
}
