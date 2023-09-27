using EmployeeAPI.Dtos;

namespace EmployeeAPI.IServices
{
    public interface IEmployeeService
    {
        Task<EmployeeGetAllResponse> GetAllEmployees(int page);
        Task<EmployeeDto?> GetEmployee(Guid id);
        Task<EmployeeDto> AddEmployee(EmployeeAddRequest employee); 
        Task<EmployeeDto> UpdateEmployee(EmployeeUpdateRequest employee); 
        Task<Guid> DeleteEmployee(Guid id);


    }
}
