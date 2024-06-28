using HelpDeskApi.ContextDefinition;
using HelpDeskApi.Services;
using HelpDeskApi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using static BCrypt.Net.BCrypt;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskApi.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost("login/")]
        public IActionResult Login([FromServices] TokenService tokenService,
                                   [FromServices] ApiContext context,
                                   [FromBody] LoginViewModel request)
        {
            var user = context.Users.Include(x => x.Role)
                                    .FirstOrDefault(x => x.Email == request.Email);
            if(user != null)
            {
                if (Verify(request.Password, user.PasswordHash))
                {
                    var token = tokenService.GenerateToken(user);
                    return Ok(token);
                }
                else
                {
                    return Ok("Usuario ou senha Invalidos");
                }
            }

            return NotFound("Usuario não encontrado");
        }

    }
}
