using Microsoft.AspNetCore.Mvc;

namespace SecurePasswords.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
