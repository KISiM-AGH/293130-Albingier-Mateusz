namespace FullStack_Project_IE_2.Core.Security.Tokens
{
    public class RefreshToken : JsonWebToken
    {
        public RefreshToken(string token, long expiration) : base(token, expiration)
        {

        }
    }
}
