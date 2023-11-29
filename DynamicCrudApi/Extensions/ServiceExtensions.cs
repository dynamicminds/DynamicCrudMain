using DynamicCrud.Api.Dto;
using DynamicCrud.Api.Interfaces;
using DynamicCrud.Api.Mapper;
using DynamicCrud.Api.Service;
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
        public static void AddServiceInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.RegisterMapperProfiles();
            services.AddCRUDServiceInfrastructure();
        }

        public static void AddCRUDServiceInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ICrudService<Genders, GenderDto>, CrudService<Genders, GenderDto>>();
            services.AddScoped<ICrudService<Roles, RolesDto>, CrudService<Roles, RolesDto>>();
            services.AddScoped<ICrudService<Employee, EmployeeDto>, CrudService<Employee, EmployeeDto>>();
        }
    }
}
