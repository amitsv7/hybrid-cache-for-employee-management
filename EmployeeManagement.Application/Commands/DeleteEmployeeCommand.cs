using EmployeeManagement.Domain.Interfaces;
using MediatR;

namespace EmployeeManagement.Application.Commands;

public record DeleteEmployeeCommand(Guid EmployeeId) : IRequest<bool>;

internal class DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    : IRequestHandler<DeleteEmployeeCommand, bool>
{
    public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        return await employeeRepository.DeleteEmployee(request.EmployeeId);
    }
}