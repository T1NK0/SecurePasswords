using Data;
using Hashing;
using Microsoft.AspNetCore.Mvc;

namespace SecurePasswords.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IHashing _hashing;

        public LoginController(DataContext dataContext, IHashing hashing)
        {
            _dataContext = dataContext;
            _hashing = hashing;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Models.LoginViewModel loginViewModel = new Models.LoginViewModel();

            return View(loginViewModel);
        }

        [HttpPost]
        public IActionResult Index(Models.LoginViewModel model)
        {
            Data.Models.Users user = _dataContext.Users.FirstOrDefault(x => x.Username.Equals(model.Username));

            string hashValue = String.Concat(model.Password + user.SaltKey);
            string newHashing = _hashing.SHA256HashValue(hashValue);
            
            if (newHashing == user.UserPassword)
            {
                //Creates a new salt, and a new hash value for the password.
                string newUserSalt = _hashing.CreateSalt();
                string newHashPassword = String.Concat(model.Password + newUserSalt);

                //Hashes with the new key, to create a pepper.
                string newHashingPassword = _hashing.SHA256HashValue(newHashPassword);

                //Sets our new password and salt on our user.
                user.UserPassword = newHashingPassword;
                user.SaltKey = newUserSalt;

                //Updates the user in the database.
                _dataContext.Update(user);
                _dataContext.SaveChanges();

                //Redirect to success on login page.
                return RedirectToAction("SuccessLogin");
            }
            else
            {
                return View(new Models.LoginViewModel(model.LoginAttempts++));
            }
        }

        [HttpGet]
        public IActionResult SuccessLogin()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FailLogin()
        {
            return View();
        }
    }
}
