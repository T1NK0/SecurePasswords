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

            string hashValue = String.Concat(model.Password, user.SaltKey);
            string newHashing = _hashing.SHA256HashValue(hashValue);

            if (newHashing == user.UserPassword)
            {
                return RedirectToAction("SuccessLogin");
            }
            else
            {
                model.loginAttempts = model.loginAttempts + 1;
            }

            return View();
                //return RedirectToAction("FailLogin");

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
