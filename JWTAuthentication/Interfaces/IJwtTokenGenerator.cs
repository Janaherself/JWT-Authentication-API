using System.Security.Claims;

namespace JWTAuthentication.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(string username);
        ClaimsPrincipal? ValidateToken(string token);
    }
}