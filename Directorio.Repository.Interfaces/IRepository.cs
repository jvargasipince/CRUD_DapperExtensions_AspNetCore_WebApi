using System.Collections.Generic;

namespace Directorio.Repository.Interfaces
{
   public interface IRepository<T> where T: class
    {

        IEnumerable<T> GetAll();
        T Get(int id);
        bool Add(T entity);
        bool Delete(T entity);
        bool Update(T entity);

    }
}
