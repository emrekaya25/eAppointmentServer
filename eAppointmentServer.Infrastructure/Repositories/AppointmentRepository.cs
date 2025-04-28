using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using eAppointmentServer.Infrastructure.Context;
using eAppointmentServer.Infrastructure.Repositories.GenericRepositories;

namespace eAppointmentServer.Infrastructure.Repositories;

public sealed class AppointmentRepository : Repository<Appointment, ApplicationDbContext> , IAppointmentRepository
{
    public AppointmentRepository(ApplicationDbContext context) : base(context)
    {

    }
}