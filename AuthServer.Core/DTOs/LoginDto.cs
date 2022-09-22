namespace AuthServer.Core.DTOs
{
    public class LoginDto
    {
        //Bu alanda stringler Email,Password benim veritabanımda
        //var ise ve eşleşirse token döneceğim.
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
