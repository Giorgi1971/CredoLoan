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
    public class LoansController : ControllerBase
    {
        private readonly ILoanService _loanService;
        private readonly UserManager<CustomerEntity> _userManager;

        public LoansController(ILoanService loanService, UserManager<CustomerEntity> userManager)
        {
            _loanService = loanService;
            _userManager = userManager;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateLoanAsync([FromBody] CreateLoanRequest request)
        {
            HttpContext httpContext = HttpContext;
            var loan = await _loanService.CreateLoanAsync(request.LoanTypeId, request.LoanAmount, request.CurrencyId, request.LoanPeriodId);
            return Ok(loan);
        }

        [HttpGet]
        public async Task<ActionResult> GetLoansAsync()
        {
            var result = await _loanService.GetLoansAsync();
            return new JsonResult(result);
        }

        [HttpGet("LoanStatuses")]
        public async Task<ActionResult> GetLoanStatusesAsync()
        {
            var result = await _loanService.GetLoanStatusesAsync();
            return new JsonResult(result);
        }

        [HttpGet("Currency")]
        public async Task<ActionResult> GetLoanCurrencyesAsync()
        {
            var result = await _loanService.GetLoanCurrencyesAsync();
            return new JsonResult(result);
        }

        [HttpGet("LoanTypes")]
        public async Task<ActionResult> GetLoantypesesAsync()
        {
            var result = await _loanService.GetLoantypesesAsync();
            return new JsonResult(result);
        }

        [HttpGet("LoanPeriods")]
        public async Task<ActionResult> GetLoanPeriodAsync()
        {
            var result = await _loanService.GetLoanPeriodAsync();
            return new JsonResult(result);
        }
    }
}
