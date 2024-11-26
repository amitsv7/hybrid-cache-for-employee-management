using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Domain.Interfaces;

public interface IEmployeeRepository
{
    Task<IEnumerable<EmployeeEntity>> GetEmployee();
    Task<EmployeeEntity> GetEmployeeById(Guid id);
    Task<EmployeeEntity> AddEmployee(EmployeeEntity entity);
    Task<EmployeeEntity> UpdateEmployee(EmployeeEntity entity);
    Task<bool> DeleteEmployee(Guid employeeId);
}