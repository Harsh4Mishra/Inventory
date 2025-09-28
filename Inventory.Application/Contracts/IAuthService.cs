using System.Security.Claims;

namespace Inventory.Application.Contracts
{
    public interface IAuthService
    {
        public string GenerateToken(Claim[] claimsIdentity);
    }
}
