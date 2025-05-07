using eAppointmentServer.Domain.Common;
using MediatR;

namespace eAppointmentServer.Application.Features.Doctors.CreateDoctor;

public sealed record CreateDoctorCommand(
    string FirstName,
    string LastName,
    int DepartmentValue) : IRequest<Result<string>>;