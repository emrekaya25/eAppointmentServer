using eAppointmentServer.Domain.Common;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eAppointmentServer.Application.Features.Patients.GetAllPatient;

internal sealed class GetAllPatientQueryHandler(
    IPatientRepository patientRepository) : IRequestHandler<GetAllPatientQuery, Result<List<Patient>>>
{
    public async Task<Result<List<Patient>>> Handle(GetAllPatientQuery request, CancellationToken cancellationToken)
    {
        List<Patient> patients = await patientRepository
            .GetAll()
            .ToListAsync();
        return patients;
    }
}