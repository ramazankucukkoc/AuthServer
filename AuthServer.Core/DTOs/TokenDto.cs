using System;

namespace AuthServer.Core.DTOs
{
    public class TokenDto
    {
        //JWT string oldugu için AccessToken string tanımlanıyor.
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpiration { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }
}
