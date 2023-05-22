using CredoLoan.Auth;
using CredoLoan.Data.Entity;
using CredoLoan.Models.Requests;
using CredoLoan.Models.Responses;
using CredoLoan.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CredoLoan.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> LoginAsync(string email, string password);
        Task<UserRegistrationResponse> UserRegistrationAsync(UserRegistrationRequest request);
    }

    public class AuthService : IAuthService
    {
        private readonly TokenGenerator _tokenGenerator;
        private readonly UserManager<CustomerEntity> _userManager;
        private readonly ICustomerRepository _customerRepository;


        public AuthService(
            UserManager<CustomerEntity> userManager,
            TokenGenerator tokenGenerator,
            ICustomerRepository customerRepository
)
        {
            _tokenGenerator = tokenGenerator;
            _userManager = userManager;
            _customerRepository = customerRepository;
        }

        public async Task<LoginResponse> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                throw new HttpRequestException("This user isn't found in database");
            var isCorrectPassword = await _userManager.CheckPasswordAsync(user, password);
            if (!isCorrectPassword)
                throw new HttpRequestException("Password isn't correct");
            var role = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>()
            {
            new Claim("role", role.First()),
            new Claim(new ClaimsIdentityOptions().UserIdClaimType, user.Id.ToString()),
            };
            return new LoginResponse
            {
                Token = _tokenGenerator.Generate(claims)
            };
        }

        public async Task<UserRegistrationResponse> UserRegistrationAsync(UserRegistrationRequest request)
        {
            //Validate(request);
            var customer = new CustomerEntity()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDate = request.BirthDate,
                Email = request.Email,
                UserName = "Jonaida",
                PersonalNumber = request.PersonalNumber
            };
            var resultCreateUser = await _userManager.CreateAsync(customer, request.Password);
            var resultAddRole = await _userManager.AddToRoleAsync(customer, "api-user");
            if (resultCreateUser.Succeeded && resultAddRole.Succeeded)
                return new UserRegistrationResponse()
                {
                    Email = request.Email,
                    BirthDate = request.BirthDate,
                    PersonalNumber = request.PersonalNumber,
                    FirstName = request.FirstName,
                    LastName = request.LastName
                };
            else
                throw new Exception("User not created");
        }

        public async Task<CustomerEntity> GetUserEntity(int id)
        {
            var user = await _customerRepository.GetUserByIdAsync(id);
            return user;
        }
    }
}
