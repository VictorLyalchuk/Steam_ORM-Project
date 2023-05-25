using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data_access_entity.Repositories
{
    public interface IRepositories<TEntity> where TEntity : class
    {
        //CRUD Interface
        IEnumerable<TEntity> GetAll();
        TEntity GetByID(int id);
        void Insert(TEntity entity);
        void Delete(int id);
        void Update(TEntity entity);
        void Save();
    }
}
