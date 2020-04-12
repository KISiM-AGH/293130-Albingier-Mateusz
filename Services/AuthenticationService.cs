using FullStack_Project_IE_2.Core.Security.Hashing;
using FullStack_Project_IE_2.Core.Security.Tokens;
using FullStack_Project_IE_2.Core.Services;
using FullStack_Project_IE_2.Core.Services.Communication;
using System.Threading.Tasks;

namespace FullStack_Project_IE_2.Services
{
    public class AuthenticationService :IAuthenticationService
    {

        private readonly IUserService userService;
        private readonly IPasswordHasher passwordHasher;
        private readonly ITokenHandler tokenHandler;

        public AuthenticationService(IUserService userService, IPasswordHasher passwordHasher, ITokenHandler tokenHandler)
        {
            this.userService = userService;
            this.passwordHasher = passwordHasher;
            this.tokenHandler = tokenHandler;
        }

        public async Task<TokenResponse> CreateAccessTokenAsync(string email, string password)
        {
            var user = await userService.FindByEmailAsync(email);

            if (user == null || !passwordHasher.PasswordMatches(password, user.Password))
            {
                return new TokenResponse(false, "Invalid credentials.", null);
            }

            var token = tokenHandler.CreateAccessToken(user);

            return new TokenResponse(true, null, token);
        }

        public async Task<TokenResponse> RefreshTokenAsync(string refreshToken, string userEmail)
        {
            var token = tokenHandler.TakeRefreshToken(refreshToken);

            if (token == null)
            {
                return new TokenResponse(false, "Invalid refresh token.", null);
            }

            if (token.IsExpired())
            {
                return new TokenResponse(false, "Expired refresh token.", null);
            }

            var user = await userService.FindByEmailAsync(userEmail);
            if (user == null)
            {
                return new TokenResponse(false, "Invalid refresh token.", null);
            }

            var accessToken = tokenHandler.CreateAccessToken(user);
            return new TokenResponse(true, null, accessToken);
        }

        public void RevokeRefreshToken(string refreshToken)
        {
            tokenHandler.RevokeRefreshToken(refreshToken);
        }
    }
}

