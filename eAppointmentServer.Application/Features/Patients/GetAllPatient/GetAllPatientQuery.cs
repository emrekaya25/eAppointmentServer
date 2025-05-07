using eAppointmentServer.Domain.Common;
using eAppointmentServer.Domain.Entities;
using MediatR;

namespace eAppointmentServer.Application.Features.Patients.GetAllPatient;

public sealed record GetAllPatientQuery() : IRequest<Result<List<Patient>>>;