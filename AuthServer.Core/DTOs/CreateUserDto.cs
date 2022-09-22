namespace AuthServer.Core.DTOs
{
    public class CreateUserDto
    {//Üyelik işlemleri için yapılan sınıf.
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
