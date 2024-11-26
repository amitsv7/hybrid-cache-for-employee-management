using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using MediatR;

namespace EmployeeManagement.Application.Queries;

public record GetAllEmployeeQuery()  : IRequest<IEnumerable<EmployeeEntity>>;

public class GetAllEmployeeQueryHandler(IEmployeeRepository employeeRepository)
    : IRequestHandler<GetAllEmployeeQuery, IEnumerable<EmployeeEntity>>
{
    public async Task<IEnumerable<EmployeeEntity>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
    {
        return await employeeRepository.GetEmployee();
    }
}