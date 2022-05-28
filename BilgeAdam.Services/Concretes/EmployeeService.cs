using BilgeAdam.Data.Context;
using BilgeAdam.Data.Entities;
using BilgeAdam.Services.Abstractions;
using BilgeAdam.Services.Contracts;

namespace BilgeAdam.Services.Concretes
{
    internal class EmployeeService : IEmployeeService
    {
        private readonly NorthwindContext context;

        public EmployeeService(NorthwindContext context)
        {
            this.context = context;
        }

        public List<EmployeeListDTO> GetEmployees()
        {
            return context.Employees.Select(s => new EmployeeListDTO
            {
                City = s.City,
                Country = s.Country,
                Id = s.EmployeeID,
                FirstName = s.FirstName,
                HomePhone = s.HomePhone,
                LastName = s.LastName
            }).ToList();
        }

        public bool CreateEmployee(NewEmployeeDTO data)
        {
            var entity = new Employee
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
                City = data.City,
                Country = data.Country,
                HomePhone = data.Phone
            };
            context.Employees.Add(entity);
            var result = context.SaveChanges();
            return result > 0;
        }
    }
}