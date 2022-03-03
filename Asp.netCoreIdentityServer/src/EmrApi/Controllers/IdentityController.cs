using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

[Route("Identity")]
[Authorize]
public class IdentityController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Content("Hello");
       // return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
    }
}