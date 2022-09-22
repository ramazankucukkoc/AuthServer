using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace MiniApp1.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StokcController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStock()
        {
            var userName=HttpContext.User.Identity.Name;
            var userIdCalim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            return Ok($"Stock işlemleri => UserName:{userName}- UserId:{userIdCalim.Value}");
        }
    }
}
