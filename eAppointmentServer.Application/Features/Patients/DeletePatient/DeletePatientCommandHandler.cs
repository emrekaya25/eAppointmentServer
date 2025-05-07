using eAppointmentServer.Domain.Common;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using eAppointmentServer.Domain.Repositories.GenericRepositories;
using MediatR;

namespace eAppointmentServer.Application.Features.Patients.DeletePatient;

internal sealed class DeletePatientCommandHandler(
    IPatientRepository patientRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeletePatientCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
    {
        Patient patient = await patientRepository.GetByExpressionAsync(x => x.Id == request.Id);
        if (patient == null)
        {
            return Result<string>.Failure("Patient is not found");
        }

        patientRepository.Delete(patient);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Patient delete is successfull");
    }
}