using DynamicCrud.Dal.EF.CF.EntityConfiguration;
using DynamicCrud.Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCrud.Dal.EF.CF
{
    public class DCDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Genders> Genders { get; set; }

        public DbSet<Roles> Roles { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public DCDbContext(DbContextOptions<DCDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new GendersConfig());
            modelBuilder.ApplyConfiguration(new RolesConfig());
            base.OnModelCreating(modelBuilder);

            ////TODO : Check for alternate approach
            //modelBuilder.Entity<Users>()
            //        .Property(e => e.DOB)
            //        .HasColumnType("date");
        }
    }
}
