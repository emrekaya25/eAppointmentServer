using eAppointmentServer.Domain.Common;
using MediatR;

namespace eAppointmentServer.Application.Features.Patients.DeletePatient;

public sealed record DeletePatientCommand(
    Guid Id) : IRequest<Result<string>>;