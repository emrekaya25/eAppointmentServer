using eAppointmentServer.Domain.Common;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using eAppointmentServer.Domain.Repositories.GenericRepositories;
using MediatR;

namespace eAppointmentServer.Application.Features.Doctors.DeleteDoctor;

internal sealed class DeleteDoctorCommandHandler(
    IDoctorRepository doctorRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteDoctorCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
    {
        Doctor doctor = await doctorRepository.GetByExpressionAsync(x => x.Id == request.Id,cancellationToken);
        if (doctor is null)
        {
            return Result<string>.Failure("Doctor is not found");
        }
        doctorRepository.Delete(doctor);
        await unitOfWork.SaveChangesAsync();

        return "Doctor successfuly deleted";
    }
}