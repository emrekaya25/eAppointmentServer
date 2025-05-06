using eAppointmentServer.Domain.Common;
using eAppointmentServer.Domain.Entities;
using MediatR;

namespace eAppointmentServer.Application.Features.Doctors.GetAllDoctor;

public sealed record GetAllDoctorQuery() : IRequest<Result<List<Doctor>>>;