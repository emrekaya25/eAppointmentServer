using AutoMapper;
using eAppointmentServer.Domain.Common;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using eAppointmentServer.Domain.Repositories.GenericRepositories;
using MediatR;

namespace eAppointmentServer.Application.Features.Doctors.UpdateDoctor;

internal sealed class UpdateDoctorCommandHandler(
    IDoctorRepository doctorRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<UpdateDoctorCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
    {
        Doctor? doctor = await doctorRepository.GetByExpressionWithTrackingAsync(x => x.Id == request.Id,cancellationToken);
        if (doctor is null)
        {
            return Result<string>.Failure("Doctor is not found");
        }
        mapper.Map(request,doctor);
        doctorRepository.Update(doctor);
        await unitOfWork.SaveChangesAsync();

        return "Doctor update is successfull";
    }
}