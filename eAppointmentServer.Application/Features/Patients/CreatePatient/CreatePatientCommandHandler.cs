using eAppointmentServer.Domain.Common;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Enums;
using eAppointmentServer.Domain.Repositories;
using eAppointmentServer.Domain.Repositories.GenericRepositories;
using MediatR;

namespace eAppointmentServer.Application.Features.Patients.CreatePatient;

internal sealed class CreatePatientCommandHandler(
    IPatientRepository patientRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreatePatientCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        Patient patient = new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            IdentityNumber = request.IdentityNumber,
            City = request.City,
            Town = request.Town,
            Address = request.Address,
            PhoneNumber = request.PhoneNumber,
            Gender = GenderEnum.FromValue(request.GenderValue)
        };

        patientRepository.Add(patient);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Patient create is successfull";
    }
}