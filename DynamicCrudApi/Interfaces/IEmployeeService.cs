using DynamicCrud.Api.Dto;

namespace DynamicCrud.Api.Interfaces
{
    public interface IEmployeeService
    {
        Task<int> AddDailyUpdate(EmployeeDto department);
        Task<List<EmployeeDto>> GetAllDailyUpdates();
        Task<EmployeeDto> GetDailyUpdateById(int id);
        Task DeleteDailyUpdate(int id);
        Task UpdateDailyUpdate(EmployeeDto employee);
    }
}
