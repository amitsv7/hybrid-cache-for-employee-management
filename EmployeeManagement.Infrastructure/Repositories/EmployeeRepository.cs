using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using EmployeeManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Repositories;

public class EmployeeRepository(ApplicationDbContext dbContext) : IEmployeeRepository
{
    public async Task<IEnumerable<EmployeeEntity>> GetEmployee()
    {
        return await dbContext.Employees.ToListAsync();
    }

    public async Task<EmployeeEntity> GetEmployeeById(Guid id)
    {
        return await dbContext.Employees.FirstOrDefaultAsync(x => x.EmpNo == id);
    }

    public async Task<EmployeeEntity> AddEmployee(EmployeeEntity entity)
    {
        entity.EmpNo = Guid.NewGuid();
        dbContext.Employees.Add(entity);

        await dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<EmployeeEntity> UpdateEmployee(EmployeeEntity entity)
    {
        var employee = await dbContext.Employees.FirstOrDefaultAsync(x => x.EmpNo == entity.EmpNo);

        if (employee is not null)
        {
            employee.FirstName = entity.FirstName;
            employee.LastName = entity.LastName;
            employee.EmpLevel = entity.EmpLevel;
            employee.Job = entity.Job;
            employee.MiddleName = entity.MiddleName;
            employee.PhoneNo = entity.PhoneNo;
            employee.Sex = entity.Sex;

            await dbContext.SaveChangesAsync();

            return employee;
        }

        return entity;
    }

    public async Task<bool> DeleteEmployee(Guid employeeId)
    {
        var employee = await dbContext.Employees.FirstOrDefaultAsync(x => x.EmpNo == employeeId);

        if (employee is not null)
        {
            dbContext.Employees.Remove(employee);

            return await dbContext.SaveChangesAsync() > 0;
        }

        return false;
    }
}