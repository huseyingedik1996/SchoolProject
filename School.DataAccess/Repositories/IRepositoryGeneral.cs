using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Repositories
{
    public interface IRepositoryGeneral<T> where T : class
    {
        Task Create(T entity);

        void Update(T entity, T unchanged);
        
        void Delete(T Entity);

        Task<List<T>> GetAll();

        Task<T> GetById(int id);

        Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool predicate = false); 



    }
}
