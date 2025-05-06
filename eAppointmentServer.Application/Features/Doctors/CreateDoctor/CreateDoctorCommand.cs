using eAppointmentServer.Domain.Common;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Enums;
using eAppointmentServer.Domain.Repositories;
using eAppointmentServer.Domain.Repositories.GenericRepositories;
using MediatR;

namespace eAppointmentServer.Application.Features.Doctors.CreateDoctor;

public sealed record CreateDoctorCommand(
    string FirstName,
    string LastName,
    int Department) : IRequest<Result<string>>;

internal sealed class CreateDoctorCommandHandler(
    IDoctorRepository doctorRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateDoctorCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
    {
        Doctor doctor = new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Department = DepartmentEnum.FromValue(request.Department)
        };

        await doctorRepository.AddAsync(doctor,cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Doctor create is successfull";
    }
}
