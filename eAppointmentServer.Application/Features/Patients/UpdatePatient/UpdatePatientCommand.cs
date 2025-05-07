using eAppointmentServer.Domain.Common;
using MediatR;

namespace eAppointmentServer.Application.Features.Patients.UpdatePatient;

public sealed record UpdatePatientCommand(
    Guid Id,
    string? FirstName,
    string? LastName,
    string? IdentityNumber,
    string? City,
    string? Town,
    string? Address,
    string? PhoneNumber,
    int GenderValue) : IRequest<Result<string>>;