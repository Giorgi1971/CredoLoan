using CredoLoan.Models.Requests;
using CredoLoan.Services;
using Microsoft.AspNetCore.Mvc;

namespace CredoLoan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IAuthService _authService;

        public CustomerController (IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
        {
            var loginResponce = await _authService.LoginAsync(request.Email, request.Password);
            return Ok(loginResponce.Token);
        }

        [HttpPost]
        [Route("register")]
        //[Authorize("API-OPERATOR", AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> CreateCustomer([FromBody] UserRegistrationRequest request)
        {
            var user = await _authService.UserRegistrationAsync(request);
            return Ok(user);
        }
    }
}
