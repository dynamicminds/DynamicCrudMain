using DynamicCrud.Dal.EF.CF.Repository;
using DynamicCrud.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCrud.Dal.EF.CF.Interfaces
{
    public interface IUnitOfWork
    {
        public IEmployeeRepository EmployeeRepository { get; }
        int SaveChanges();
    }

    public interface ICRUD<T> : IRepository<T>
        where T : class, new()
    {
        public IRepository<T> DB { get; }
        int SaveChanges();
    }
}
