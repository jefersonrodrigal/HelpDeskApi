using HelpDeskApi.ContextDefinition;
using HelpDeskApi.Models;
using HelpDeskApi.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HelpDeskApi.Controllers
{
    [ApiController]
    public class ReportController : ControllerBase
    {
        [Authorize(Roles = "Usuario")]
        [HttpGet("perfil/")]
        public IActionResult GetRepoorts([FromServices] ApiContext context)
        {
            var reports = context.Reports.Where(x => x.User.Name == User.Identity.Name)
                                         .ToList();

            return Ok(reports);
        }

        [Authorize(Roles = "Usuario")]
        [HttpPost("criarchamado/")]
        public IActionResult CreateReport([FromServices] ApiContext context,
                                          [FromBody] ReportViewModel request)
        {
           var user = context.Users.FirstOrDefault(x => x.Name == User.Identity.Name);

           var report = new Report
            {
                Subject = request.Subject,
                Incident = request.Incident,
                User = user
            };

            context.Reports.Add(report);
            
            context.SaveChanges();
           
            return Ok(report);
        }
    }
}
