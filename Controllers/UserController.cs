using HelpDeskApi.ContextDefinition;
using HelpDeskApi.Models;
using HelpDeskApi.ViewModel;
using static BCrypt.Net.BCrypt;
using Microsoft.AspNetCore.Mvc;

namespace HelpDeskApi.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost("criarusuario/")]
        public IActionResult CreateUser([FromServices] ApiContext context,
                                        [FromBody] CreateUserViewModel request)
        {
            var role = context.Roles.FirstOrDefault(x => x.Name == request.UserProfile);

            if (role == null)
            {
                return NotFound("Perfil Inesistente");
            }

            var passHash = HashPassword(request.UserPassword, 12);

            var user = new User
            {
                Name = request.UserName,
                LastName = request.UserLastName,
                Email = request.UserEmail,
                PasswordHash = passHash,
                Role = role
            };


            context.Users.Add(user);
            context.SaveChanges();

            return Ok();
        }
    }
}
