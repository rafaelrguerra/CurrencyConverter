using CurrencyConverter.Models;
using CurrencyConverter.Repositories;
using CurrencyConverter.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CurrencyConverter.Controllers
{
    [Route("v1/account")]
    public class HomeController : Controller
    {
        private readonly IUserRepository _userRepository;
        public HomeController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {

            var user = _userRepository.Get(model.Username, model.Password);

            if (user == null)
                return NotFound(new { message = "Wrong user or password" });

            var token = TokenService.GenerateToken(user);
            user.Password = "";
            return new { user = user, token = token };
        }
    }
}
