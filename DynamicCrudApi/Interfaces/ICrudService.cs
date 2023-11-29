using DynamicCrud.Api.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCrud.Api.Interfaces
{
    public interface ICrudService<Entity,Dto>
        where Entity : class, new()
        where Dto : class
    {
        Task<List<Dto>> GetAll();

        Task<Dto> GetById(int id);

        Task<int> Add(Dto dto);

        Task Update(int id, Dto dto);

        Task Delete(int id);
    }
}
