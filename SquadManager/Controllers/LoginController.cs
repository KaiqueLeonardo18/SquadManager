using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SquadManager.Models;
using SquadManager.Validator;

namespace SquadManager.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            UserViewModel vm = new UserViewModel();

            UserValidator validator = new UserValidator();

            ValidationResult results = validator.Validate(vm);

            if(!results.IsValid)
            {
                foreach(var failure in results.Errors)
                {
                    Console.WriteLine("Property " + failure.PropertyName + " failed validation");
                }
            }

            return View("Index", vm);
        }

        [HttpPost]
        public IActionResult Teste(UserViewModel user) 
        {
            user.Email = "oi";

            return View("Index", user);
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult Forgot()
        {
            return View();
        }

        public IActionResult Reset()
        {
            return View();
        }
    }
}
