using Microsoft.AspNetCore.Mvc;

namespace JWTAuthentication.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController(JwtTokenGenerator tokenGenerator) : ControllerBase
    {
        private readonly JwtTokenGenerator _tokenGenerator = tokenGenerator;

        [HttpGet]
        public IActionResult Login(UserLogin request)
        {
            if (IsValidUser(request.Username, request.Password))
            {
                var token = _tokenGenerator.GenerateToken(request.Username);
                return Ok(new { Token = token });
            }
            return Unauthorized();
        }

        private bool IsValidUser(string username, string password)
        {
            return username == "guest" && password == "guest";
        }
    }
}
