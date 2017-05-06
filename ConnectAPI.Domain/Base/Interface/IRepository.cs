using ConnectAPI.Domain.Base.Filter;
using System.Collections.Generic;

namespace ConnectAPI.Domain.Base.Interface
{
    public interface IRepositor<T> where T : class
    {
        T Save(T entity);
        T Update(T entity);
        void Delete(int id);
        T GetById(int id);
        IEnumerable<T> Search(IEnumerable<BaseFilter> filters);
        IEnumerable<T> GetAll();
    }
}
