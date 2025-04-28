using eAppointmentServer.Application.Services;
using eAppointmentServer.Domain.Common;
using eAppointmentServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eAppointmentServer.Application.Features.Auth.Login;

                                        // Primary Constructor .NET 8 ile geldi.
internal sealed class LoginCommandHandler(UserManager<AppUser> userManager , IJwtProvider jwtProvider) : IRequestHandler<LoginCommand, Result<LoginCommandResponse>>
{
    public async Task<Result<LoginCommandResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        AppUser? appUser = await userManager.Users.FirstOrDefaultAsync(x => x.UserName == request.UserNameOrEmail || x.Email == request.UserNameOrEmail, cancellationToken);
        if (appUser is null)
        {
           return Result<LoginCommandResponse>.Failure(500,"User not found");
        }
        bool isPasswordCorrect = await userManager.CheckPasswordAsync(appUser!,request.Password);
        if (!isPasswordCorrect)
        {
           return  Result<LoginCommandResponse>.Failure("Username or Password is wrong");
        }

        string token = jwtProvider.CreateToken(appUser);
        LoginCommandResponse response = new(token);

        return Result<LoginCommandResponse>.Succeed(response);
    }
}