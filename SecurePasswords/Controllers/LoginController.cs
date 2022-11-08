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

            return View();
        }
    }
}
