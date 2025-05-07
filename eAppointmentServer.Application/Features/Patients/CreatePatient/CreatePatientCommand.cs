using eAppointmentServer.Domain.Common;
using MediatR;

namespace eAppointmentServer.Application.Features.Patients.CreatePatient;

public sealed record CreatePatientCommand(
    string FirstName,
    string LastName,
    string IdentityNumber,
    string City,
    string Town,
    string Address,
    string PhoneNumber,
    int GenderValue) : IRequest<Result<string>>;