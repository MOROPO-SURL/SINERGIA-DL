using Microsoft.Extensions.Options;
using MOROPO.GEDET.CAM.Presentation.Web.API.Configurations;
using System.Security.Claims;

namespace MOROPO.GEDET.CAM.Presentation.Web.API.Extensions;

internal static class ClaimIdentityExtensions
{
    public static string ToBearerToken(this ClaimsIdentity target, IOptions<JWTConfiguration> jwtConfigurationOptions)
    {
        var key = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtConfigurationOptions.Value.JwtSecretKey));
        var creds = new Microsoft.IdentityModel.Tokens.SigningCredentials(key, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256);
        var expires = DateTime.Now.AddSeconds(jwtConfigurationOptions.Value.ExpiresInSecond);

        List<Claim> claims = [.. target.Claims];

        claims.Add(new Claim(ClaimsIdentity.DefaultIssuer, jwtConfigurationOptions.Value.Issuer));

        var token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(
            jwtConfigurationOptions.Value.Issuer,
            null,
            claims,
            expires: expires,
            signingCredentials: creds
        );

        return new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler().WriteToken(token);
    }
}
