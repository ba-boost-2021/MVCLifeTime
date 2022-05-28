using BilgeAdam.Services.Contracts;

namespace BilgeAdam.Services.Abstractions
{
    public interface IEmployeeService
    {
        List<EmployeeListDTO> GetEmployees();
        bool CreateEmployee(NewEmployeeDTO data);
    }
}