using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RestaurantReservation.Db.Entities;
using RestaurantReservation.DTO;
using RestaurantReservationAPI.Service.IServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestaurantReservationAPI.Controllers
{
    [Route("api/v1.0/")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public AuthenticationController(IUserService userService, IConfiguration configuration, IMapper mapper)
        {
            _userService = userService ??
                throw new ArgumentNullException(nameof(userService));
            _configuration = configuration ??
                throw new ArgumentNullException(nameof(configuration));
            _mapper = mapper ?? throw new ArgumentNullException();
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<User>> Authenticate(
            AuthenticationRequestBody authenticationRequestBody)
        {
            if (authenticationRequestBody == null || string.IsNullOrEmpty(authenticationRequestBody.Username) || string.IsNullOrEmpty(authenticationRequestBody.Password))
            {
                return BadRequest(new { message = "Invalid input. Username and password are both required." });
            }
            User user = await _userService.UserByNameAndPassword(
                authenticationRequestBody.Username,
                authenticationRequestBody.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
            var signingCredentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", authenticationRequestBody.Username));
            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signingCredentials);
            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);
            return Ok(tokenToReturn);
        }

        [HttpPost("signup")]
        public async Task<ActionResult> Signup(AuthenticationRequestBody authenticationRequestBody)
        {
            if (authenticationRequestBody == null || string.IsNullOrEmpty(authenticationRequestBody.Username) || string.IsNullOrEmpty(authenticationRequestBody.Password))
            {
                return BadRequest(new { message = "Invalid input. Username and password are both required." });
            }
            bool isUsernameTaken = await _userService.UserNameIsTaken(authenticationRequestBody.Username);
            if (isUsernameTaken)
            {
                return Conflict(new { message = "Username is already taken." });
            }
            User newUser = _mapper.Map<User>(authenticationRequestBody);

            _userService.AddAsync(newUser);
            return Ok();
        }

        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("users/{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "User not found." });
            }
            return Ok(user);
        }
    }
}