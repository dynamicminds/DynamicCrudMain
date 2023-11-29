using AutoMapper;
using DynamicCrud.Api.Dto;
using DynamicCrud.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCrud.Api.Mapper
{
    public class CrudMapper : Profile
    {
        public CrudMapper()
        {
            CreateMap<EmployeeDto, Employee>()
                .ReverseMap();

            CreateMap<GenderDto, Genders>()
                .ReverseMap();

            CreateMap<RolesDto, Roles>()
                .ReverseMap();
        }
    }
}
