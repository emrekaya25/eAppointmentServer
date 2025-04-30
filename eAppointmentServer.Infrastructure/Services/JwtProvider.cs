using eAppointmentServer.Application.Services;
using eAppointmentServer.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eAppointmentServer.Infrastructure.Services;

internal sealed class JwtProvider : IJwtProvider
{
    public string CreateToken(AppUser user)
    {
        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.FullName),
            new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
            new Claim(ClaimTypes.MobilePhone, user.PhoneNumber ?? string.Empty),
            new Claim("UserName", user.Email ?? string.Empty)
        };

        DateTime expires = DateTime.Now.AddHours(2);

        SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes("www.eappointment.net www.eappointment.net www.eappointment.net Emre  Kaya  www.eappointment.net www.eappointment.net www.eappointment.net Emre  Kaya "));
        SigningCredentials signingCredentials = new(symmetricSecurityKey, SecurityAlgorithms.HmacSha512);

        JwtSecurityToken jwtSecurityToken = new(
            issuer: "Emre Kaya", // kim oluşturdu.
            audience: "eRandevu", // kim kullanacak
            claims: claims,
            notBefore: DateTime.Now,
            expires: expires,
            signingCredentials: signingCredentials);

        JwtSecurityTokenHandler handler = new();

        string token = handler.WriteToken(jwtSecurityToken);

        return token;
    }
}
