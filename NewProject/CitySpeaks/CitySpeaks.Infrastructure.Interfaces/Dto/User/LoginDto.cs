namespace CitySpeaks.Infrastructure.Interfaces.Dto.User
{
    public class LoginDto
    {
        public string Email { get; }

        public string Password { get; }

        public LoginDto(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
