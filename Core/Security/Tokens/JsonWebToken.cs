using System;

namespace FullStack_Project_IE_2.Core.Security.Tokens
{
    public abstract class JsonWebToken
    {
        public string Token { get; protected set; }
        public long Expiration { get; protected set;}

        protected JsonWebToken(string token, long expiration)
        {
            
            if(string.IsNullOrWhiteSpace(token)) throw new ArgumentException("WTF dude w ur token");
            if(expiration<=0) throw new ArgumentException("Too late");
            
            Token = token;
            Expiration = expiration;
        }

        public bool IsExpired()=>DateTime.UtcNow.Ticks>Expiration;
    }
}
