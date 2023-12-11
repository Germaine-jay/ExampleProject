using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace ExampleProject.Controllers
{
    [Route("api/[controller]")]
        [EnableCors("CorsPolicy")]
    [ApiController]
    public class ExternalLoginController : ControllerBase
    {

        public ExternalLoginController( )
        {
         
        }


        [EnableCors("CorsPolicy")]
        [HttpGet("microsoft")]
        public IActionResult MicrosoftLogin()
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = "/api/ExternalLogin/microsoft-callback",
            };
            return Challenge(properties, MicrosoftAccountDefaults.AuthenticationScheme);
        }

        
        [HttpGet("microsoft-callback")]
        public async Task<IActionResult> MicrosoftCallback()
        {
            var result = await HttpContext.AuthenticateAsync(MicrosoftAccountDefaults.AuthenticationScheme);
            var principal = HttpContext.User.Claims;
            var pri = HttpContext.Response;
      
            // You can access user information from the `principal` object.
            // For example, principal.FindFirst(ClaimTypes.Email).Value
            if (principal != null)
            {


                var nameClaim = result.Principal.FindFirst("name");
                var emailClaim = result.Principal.FindFirst("email");
                // Redirect or respond as needed
                return Ok($"Successfully authenticated. email == {nameClaim.Value}\n\n name == {emailClaim.Value}\n\n ");
            }
            return BadRequest(principal);
        }

    }
}
