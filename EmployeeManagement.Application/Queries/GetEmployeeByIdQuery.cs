using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using MediatR;

namespace EmployeeManagement.Application.Queries;

public record GetEmployeeByIdQuery(Guid EmployeeId) : IRequest<EmployeeEntity>;


public class GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository)
    : IRequestHandler<GetEmployeeByIdQuery, EmployeeEntity>
{
    public async Task<EmployeeEntity> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        return await employeeRepository.GetEmployeeById(request.EmployeeId);
    }
}