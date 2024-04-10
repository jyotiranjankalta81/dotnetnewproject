using System;

namespace api.Dtos.Account
{
    public class NewUserDto
    {
        private string _userName = string.Empty;
        private string _email = string.Empty;
        private string _token = string.Empty;

        public string UserName
        {
            get => _userName;
            set => _userName = value ?? throw new ArgumentNullException(nameof(value), "User name cannot be null");
        }

        public string Email
        {
            get => _email;
            set => _email = value ?? throw new ArgumentNullException(nameof(value), "Email cannot be null");
        }

        public string Token
        {
            get => _token;
            set => _token = value ?? throw new ArgumentNullException(nameof(value), "Token cannot be null");
        }
    }
}
