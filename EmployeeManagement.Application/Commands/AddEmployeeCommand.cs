using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using MediatR;

namespace EmployeeManagement.Application.Commands;

public record AddEmployeeCommand(EmployeeEntity Employee) : IRequest<EmployeeEntity>;


public class AddEmployeeCommandHandler(IEmployeeRepository employeeRepository, IPublisher mediator)
    : IRequestHandler<AddEmployeeCommand, EmployeeEntity>
{
    public async Task<EmployeeEntity> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
    {
        var user = await employeeRepository.AddEmployee(request.Employee);
        return user;
    }
}