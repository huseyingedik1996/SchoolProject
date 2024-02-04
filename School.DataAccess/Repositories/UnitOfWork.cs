using School.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchoolContext _context;

        public UnitOfWork(SchoolContext context)
        {
            _context = context;
        }

        public IRepositoryGeneral<T> GetRepositores<T>() where T : class
        {
            return new RepositoryGeneral<T>(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync(); 
        }
    }
}
