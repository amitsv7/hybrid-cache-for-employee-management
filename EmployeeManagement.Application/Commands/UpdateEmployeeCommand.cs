using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using MediatR;

namespace EmployeeManagement.Application.Commands;

public record UpdateEmployeeCommand(EmployeeEntity Employee)
    : IRequest<EmployeeEntity>;
    
public class UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    : IRequestHandler<UpdateEmployeeCommand, EmployeeEntity>
{
    public async Task<EmployeeEntity> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        return await employeeRepository.UpdateEmployee(request.Employee);
    }
}