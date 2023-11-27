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
        TEntity GetById(long id);
        TEntity GetByName(string name);
        List<TEntity> GetList();
        TEntity Update(TEntity entity);
        TEntity Delete(long id);
        TEntity Add(TEntity entity);
    }
}
