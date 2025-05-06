using eAppointmentServer.Domain.Common;
using MediatR;

namespace eAppointmentServer.Application.Features.Doctors.DeleteDoctor;

public sealed record DeleteDoctorCommand(
    Guid Id) : IRequest<Result<string>>;