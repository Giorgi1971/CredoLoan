using CredoLoan.Data.Entity;
using CredoLoan.Models.Requests;
using CredoLoan.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CredoLoan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {

        private readonly ILoanService _loanService;
        private readonly UserManager<CustomerEntity> _userManager;

        public LoanController(ILoanService loanService, UserManager<CustomerEntity> userManager)
        {
            _loanService = loanService;
            _userManager = userManager;
        }

        [HttpPost("create")]
        public async Task<IActionResult> LoginAsync([FromBody] CreateLoanRequest request)
        {
            HttpContext httpContext = HttpContext;
            var loan = await _loanService.CreateLoanAsync((int)request.LoanType, request.LoanAmount, (int)request.Currency, request.LoanMonth);
            return Ok();
        }
    }
}
