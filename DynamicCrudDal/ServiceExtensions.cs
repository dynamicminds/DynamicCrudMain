using DynamicCrud.Dal.EF.CF.Interfaces;
using DynamicCrud.Dal.EF.CF.Repository;
using DynamicCrud.Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DynamicCrud.Dal.EF.CF
{
    public static class ServiceExtensions
    {
        public static void AddDataInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DCDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(DCDbContext).Assembly.FullName))
            .ConfigureWarnings(wc => wc.Ignore(RelationalEventId.BoolWithDefaultWarning))
            );

            //services.AddScoped<IDailyUpdatesRepository, DailyUpdatesRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddCRUDDataInfrastructure();
        }

        public static void AddCRUDDataInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Employee>, BaseRepository<Employee>>();
            services.AddScoped<ICRUD<Employee>, CRUD<Employee>>();
            services.AddScoped<IRepository<Roles>, BaseRepository<Roles>>();
            services.AddScoped<ICRUD<Roles>, CRUD<Roles>>();
            services.AddScoped<IRepository<Genders>, BaseRepository<Genders>>();
            services.AddScoped<ICRUD<Genders>, CRUD<Genders>>();
        }
    }
}
