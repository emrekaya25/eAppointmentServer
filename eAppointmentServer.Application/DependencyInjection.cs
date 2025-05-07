using Microsoft.Extensions.DependencyInjection;

namespace eAppointmentServer.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DependencyInjection).Assembly);

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly); // Application katmanının assemblysini mediatr'a veriyoruz. Bu sayede Mediatr buradaki yapılara erişebiliyor.
        });                                                                                   // WebAPI -> request ve response'u bilir. Aradaki tüm işlemi yapan handle classını bilmez. O class'ı bu DI kısmı kendi yönetiyor.

        return services;
    }
}
