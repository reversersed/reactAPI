using API.DAL.Models.Data;
using API.DAL.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signManager;

        public UserController(UserManager<User> userManager, SignInManager<User> signManager)
        {
            this.signManager = signManager;
            this.userManager = userManager;
        }

        [Route("login")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Введены неверные данные", error = ModelState.Values.SelectMany(e => e.Errors.Select(r => r.ErrorMessage)) });
            }

            var response = await signManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
            if (!response.Succeeded)
            {
                return BadRequest(new { message = "Пользователя с такими данными не существует", error = ModelState.Values.SelectMany(e => e.Errors.Select(r => r.ErrorMessage)) });
            }

            return Ok(new { message = "Пользователь авторизован", username = model.Username });
        }
        [Route("register")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Введены неверные данные", error = ModelState.Values.SelectMany(e => e.Errors.Select(r => r.ErrorMessage))});
            }
            User user = new() { UserName = model.Username };
            var response = await userManager.CreateAsync(user, model.Password);

            if(!response.Succeeded)
            {
                response.Errors.ToList().ForEach(i => ModelState.AddModelError(string.Empty, i.Description));
                return BadRequest(new {message = "Во время регистрации произошла ошибка", error = ModelState.Values.SelectMany(e => e.Errors.Select(r => r.ErrorMessage)) });
            }

            await signManager.SignInAsync(user, false);
            return Ok(new { message = "Пользователь " + user.UserName + " зарегистрирован" });
        }
        [Route("logout")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            User usr = await userManager.GetUserAsync(HttpContext.User);
            if (usr == null)
            {
                return Unauthorized(new { message = "Пользователь не авторизован" });
            }
            // Удаление куки
            await signManager.SignOutAsync();
            return Ok(new { message = "Выполнен выход", userName = usr.UserName });
        }
        [Route("isauth")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> IsAuthenticated()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            if (user == null)
                return Unauthorized(new { message = "Гость" });
            return Ok(new { message = "Вход выполнен", username = user.UserName });
        }
    }
}
