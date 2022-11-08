using Data;
using Data.Models;
using Hashing;
using Microsoft.AspNetCore.Mvc;
using SecurePasswords.Models;
using System.Diagnostics;

namespace SecurePasswords.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //Instantiates when constructor is called through dependency injection.
        private readonly DataContext dataContext;
        private readonly IHashing Hashings = new Hashings();

        public HomeController(ILogger<HomeController> logger, DataContext dataContext )
        {
            _logger = logger;
            this.dataContext = dataContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            Models.UserViewModel model = new Models.UserViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult CreateUser(Models.UserViewModel model)
        {
            //System.Diagnostics.Debugger.Break();

            //Logic to add user to DB
            Users newUser = new Users();

            newUser.Username = model.Username;

            newUser.SaltKey = Hashings.CreateSalt(model.SaltKey);

            string passwordWithSalt = String.Concat(model.Password + newUser.SaltKey);
            string passwordHashed = Hashings.SHA256HashValue(passwordWithSalt);
            newUser.UserPassword = passwordHashed;


            dataContext.Users.Add(newUser);
            dataContext.SaveChanges();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}