using API.BLL.Interfaces;
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
        private readonly IAccountManager accountManager;

        public UserController(UserManager<User> userManager, SignInManager<User> signManager, IAccountManager accountManager)
        {
            this.signManager = signManager;
            this.userManager = userManager;
            this.accountManager = accountManager;
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
            var user = await userManager.FindByNameAsync(model.Username);
            var roles = await userManager.GetRolesAsync(user);
            return Ok(new { message = "Пользователь авторизован", username = model.Username, userRole = roles.FirstOrDefault() });
        }
        [Route("register")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "Введены неверные данные", error = ModelState.Values.SelectMany(e => e.Errors.Select(r => r.ErrorMessage)) });
            }
            User user = new() { UserName = model.Username };
            var response = await userManager.CreateAsync(user, model.Password);

            if (!response.Succeeded)
            {
                response.Errors.ToList().ForEach(i => ModelState.AddModelError(string.Empty, i.Description));
                return BadRequest(new { message = "Во время регистрации произошла ошибка", error = ModelState.Values.SelectMany(e => e.Errors.Select(r => r.ErrorMessage)) });
            }

            await userManager.AddToRoleAsync(user, "user");
            await signManager.SignInAsync(user, false);
            return Ok(new { message = "Пользователь " + user.UserName + " зарегистрирован", userName = user.UserName, userRole = "user" });
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
            var roles = await userManager.GetRolesAsync(user);
            return Ok(new { message = "Вход выполнен", username = user.UserName, userRole = roles.FirstOrDefault() });
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUser()
        {
            return Ok(await accountManager.GetUser(HttpContext.User.Identity.Name));
        }
        [HttpPost, Route("replenish")]
        [Authorize]
        public async Task<IActionResult> Pay([FromBody] int value)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            if (user == null)
                return Unauthorized();
            user.Balance += value;
            await accountManager.CreateReplenishment(user, value);
            await userManager.UpdateAsync(user);
            return Ok();
        }
        [HttpPost, Route("subscribe")]
        [Authorize]
        public async Task<ActionResult<Subscribtion>> CreateSubscription([FromBody] string body)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            if (user == null)
                return Unauthorized();
            int cost = Int32.Parse(body.Split("|")[0]);
            List<int> genres = new();
            body.Split("|")[1].Split(",").ToList().ForEach(i => genres.Add(Int32.Parse(i)));
            user.Balance -= cost;
            await userManager.UpdateAsync(user);
            return Ok(await accountManager.CreateSubscription(user, cost, genres.ToArray()));
        }
        [HttpDelete("unsubscribe/{id}")]
        [Authorize]
        public async Task<IActionResult> RemoveSubscription(int id)
        {
            await accountManager.RemoveSubscription(id, HttpContext.User.Identity.Name);
            return NoContent();
        }
    }
}
