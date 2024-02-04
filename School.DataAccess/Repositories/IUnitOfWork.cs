using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Repositories
{
    public interface IUnitOfWork
    {
        IRepositoryGeneral<T> GetRepositores<T>() where T : class;
        Task SaveChangesAsync();
    }
}
