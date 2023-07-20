using API.Services;
using Common;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SquadManager.Validator;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IUserService _userService;

        public UserController(IPersonService personService, IUserService userService)
        {
            _personService = personService;
            _userService = userService;
        }


        /// <summary>
        /// API para efetuar login
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(UserModel user)
        {
            if (user.Password == "123")
                return Ok(new { response = "OK" });
            else
                return Ok(new { response = "ERROR" });
        }

        /// <summary>
        /// API para criar usuario.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public IActionResult Create(UserModel user)
        {
            UserValidator validator = new UserValidator();

            ValidationResult results = validator.Validate(user);

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    Console.WriteLine("Property " + failure.PropertyName + " failed validation");
                }

                return Ok(new { response = "OK" });
            }

            var userId = _personService.AddPerson(new PersonModel()
            {
                Email = user.Person.Email,
                Username = user.Person.Username
            });

            _userService.AddUser(new UserModel()
            {
                PersonId = userId,
                Password = user.Password
            });


            return Ok(new { response = "OK" });
        }

        /// <summary>
        /// API para edição de Usuário
        /// </summary>
        /// <param name="user"></param>
        /// <returns>OK</returns>
        [HttpPatch("update")]
        public IActionResult Update(UserModel user)
        {
            _userService.UpdateUser(user);

            _personService.UpdatePerson(user.Person);

            return Ok(new { response = "OK" });
        }

        /// <summary>
        /// API para recuperar senha.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("forgot")]
        public IActionResult Forgot([FromBody]string email)
        {
            return Ok(new { response = "OK" });
        }

        /// <summary>
        /// API para redefinir senha
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("reset")]
        public IActionResult Reset(UserModel user)
        {
            return Ok(new { response = "OK" });
        }

        [HttpGet("teste")]
        public IActionResult Reset()
        {
            _personService.AddPerson(new PersonModel()
            {
                Email = "KaiquinhoGostosinho@email",
                Username = "User Test"
            });
            return Ok(new { response = "OK" });
        }
    }
}
