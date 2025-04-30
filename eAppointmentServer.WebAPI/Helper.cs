using eAppointmentServer.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace eAppointmentServer.WebAPI;

public static class Helper
{
    public static async Task CreateUserAsync(WebApplication app)
    {
        using (var scoped = app.Services.CreateScope())
        {
            var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            if (!userManager.Users.Any())
            {
                AppUser user = new AppUser()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Emre",
                    LastName = "Kaya",
                    Email = "emre@gmail.com",
                    UserName = "admin",
                    EmailConfirmed = false,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 5
                };
                var isThat = await userManager.CreateAsync(user,"1");
            }
        }
    }
}
