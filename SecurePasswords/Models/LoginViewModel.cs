namespace SecurePasswords.Models
{
    public class LoginViewModel
    {
        private string _username;
        private string _password;
        private int _loginAttempts;

        public LoginViewModel()
        {

        }

        public LoginViewModel(int loginAttempts)
        {
            _loginAttempts += loginAttempts;
        }

        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public int LoginAttempts { get => _loginAttempts; set => _loginAttempts = value; }
    }
}
