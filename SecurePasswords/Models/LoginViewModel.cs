namespace SecurePasswords.Models
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {

        }

        public LoginViewModel(int loginAttempts)
        {
            LoginAttempts = loginAttempts;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public int LoginAttempts { get; set; }
        public bool accountInTimeout { get; set; }
    }
}
