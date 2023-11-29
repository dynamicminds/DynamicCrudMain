using DynamicCrud.Dal.EF.CF.Repository;
using DynamicCrud.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCrud.Dal.EF.CF.Interfaces
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DCDbContext gtDbContext;

        public UnitOfWork(DCDbContext gtDbContext)
        {
            this.gtDbContext = gtDbContext;
        }

        public IEmployeeRepository EmployeeRepository { get; }

        public int SaveChanges()
        {
            return this.gtDbContext.SaveChanges();
        }
    }

    public class CRUD<T> : BaseRepository<T>, ICRUD<T>
        where T : class, new()
    {
        private readonly DCDbContext gtDbContext;

        public CRUD(DCDbContext gtDbContext
            , IRepository<T> db) : base(gtDbContext)
        {
            this.gtDbContext = gtDbContext;
            this.DB = db;
        }

        public IRepository<T> DB { get; }

        public int SaveChanges()
        {
            return this.gtDbContext.SaveChanges();
        }
    }
}
