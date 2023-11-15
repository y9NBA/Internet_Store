using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IBaseReposiroty<TEntity>
    {
        TEntity GetById(int id);
        TEntity GetByName(string name);
        List<TEntity> GetList();
    }
}
