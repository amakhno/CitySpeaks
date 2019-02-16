namespace CitySpeaks.Infrastructure.Interfaces.Dto.User
{
    public class RegisterDto
    {
        public string Email { get; }

        public string Password { get; }

        public RegisterDto(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
