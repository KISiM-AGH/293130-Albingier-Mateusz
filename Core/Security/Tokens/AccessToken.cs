using System;

namespace FullStack_Project_IE_2.Core.Security.Tokens
{
    public class AccessToken : JsonWebToken
    {
        public RefreshToken RefreshToken { get; private set;}

        public AccessToken(string token, long expiration, RefreshToken refreshToken) : base(token, expiration)
        {
            if(refreshToken == null) throw new ArgumentException("Specify a valid refresh token");
            RefreshToken = refreshToken;
        
        
            RefreshToken = refreshToken;
        }
    }
}
