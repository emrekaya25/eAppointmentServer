using eAppointmentServer.Application.Services;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Domain.Repositories;
using eAppointmentServer.Domain.Repositories.GenericRepositories;
using eAppointmentServer.Infrastructure.Context;
using eAppointmentServer.Infrastructure.Repositories;
using eAppointmentServer.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eAppointmentServer.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
        });
        services.AddIdentity<AppUser, AppRole>(action =>
        {
            action.Password.RequiredLength = 1;
            action.Password.RequireUppercase = false;
            action.Password.RequireLowercase = false;
            action.Password.RequireNonAlphanumeric = false;
            action.Password.RequireDigit = false;
        }).AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IAppointmentRepository,AppointmentRepository>();
        services.AddScoped<IDoctorRepository,DoctorRepository>();
        services.AddScoped<IPatientRepository,PatientRepository>();

        services.AddScoped<IJwtProvider, JwtProvider>();

        /* Scrutor kütüphanesi kullanılırsa AddScoped yazmak yerine kendisi şu şekilde otomatik şekilde DI yapılır.
         * services.Scan(action => 
         *  {
         *      action
         *      .FromAssemblies(typeof(DependencyInjection).Assembly)
         *      .AddClasses(publicOnly:false)
         *      .UsingRegistration(registrationStrategy: RegistrationStrategy.Skip)
         *      .AsImplementedInterfaces()
         *      .WithScopedLifeTime();
         *  }
         * );
         */

        return services;
    }
}
