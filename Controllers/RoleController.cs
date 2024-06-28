using HelpDeskApi.ContextDefinition;
using HelpDeskApi.Models;
using HelpDeskApi.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HelpDeskApi.Controllers
{
    [ApiController]
    public class RoleController : ControllerBase
    {
        [HttpPost("criarperfil/")]
        public IActionResult CreateRole([FromServices] ApiContext context, [FromBody] CreateRoleViewModel request)
        {
            var role = new Role
            {
                Name = request.Name,
                Description = request.Description
            };
            context.Roles.Add(role);
            context.SaveChanges();

            return Ok();
        }
    }
}
