using FullStack_Project_IE_2.Core.Services.Communication;
using System.Threading.Tasks;

namespace FullStack_Project_IE_2.Core.Services
{
    public interface IAuthenticationService
    {
        Task<TokenResponse> CreateAccessTokenAsync(string email, string password);
        Task<TokenResponse> RefreshTokenAsync(string refreshToken, string userEmail);
        void RevokeRefreshToken(string refreshToken);
    }
}
