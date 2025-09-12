using System.Security.Claims;

namespace PostApp.Application.Interfaces.Services;

public interface IJwtService
{
    string GenerateToken(string userId, string username, string role);
    ClaimsPrincipal? ValidateToken(string token);
    IEnumerable<Claim> GetClaimsFromToken(string token);
}