using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using eAppointmentServer.Infrastructure.Context;
using eAppointmentServer.Infrastructure.Repositories.GenericRepositories;

namespace eAppointmentServer.Infrastructure.Repositories;

public sealed class DoctorRepository : Repository<Doctor, ApplicationDbContext> , IDoctorRepository
{
    public DoctorRepository(ApplicationDbContext context) : base(context)
    {

    }
}