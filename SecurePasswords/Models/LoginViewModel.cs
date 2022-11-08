namespace SecurePasswords.Models
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int loginAttempts { get; set; }
        public bool accountInTimeout { get; set; }
    }
}
