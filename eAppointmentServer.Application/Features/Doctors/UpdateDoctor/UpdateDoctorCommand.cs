using eAppointmentServer.Domain.Common;
using MediatR;

namespace eAppointmentServer.Application.Features.Doctors.UpdateDoctor;

public sealed record UpdateDoctorCommand(
    Guid Id,
    string FirstName,
    string LastName,
    int DepartmentValue
    ) : IRequest<Result<string>>;