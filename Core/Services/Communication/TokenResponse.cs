using FullStack_Project_IE_2.Core.Security.Tokens;
using FullStack_Project_IE_2.Domain.Services.Communication;

namespace FullStack_Project_IE_2.Core.Services.Communication
{
    public class TokenResponse : BaseResponse
    {
        public AccessToken Token { get; set;}

        public TokenResponse(bool success, string message, AccessToken token) : base(success, message)
        {
            Token = token;
        }
    }
}
