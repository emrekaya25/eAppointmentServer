using AutoMapper;
using eAppointmentServer.Domain.Common;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using eAppointmentServer.Domain.Repositories.GenericRepositories;
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

internal sealed class UpdatePatientCommandHandler(
    IPatientRepository patientRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdatePatientCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        Patient patient = await patientRepository.GetByExpressionWithTrackingAsync(x => x.Id == request.Id, cancellationToken);
        if (patient is null)
        {
            return Result<string>.Failure("Patient is not found");
        }

        mapper.Map(request,patient);
        patientRepository.Update(patient);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<string>.Succeed("Patient update is successfull");
    }
}
