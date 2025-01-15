using IdentityService.DataAccess.Repository;
using IdentityService.Entitiess;
using IdentityService.Web_API.DTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityService.Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {

        private readonly UserManager<CustomIdentityUser> _userManager;
        private readonly SignInManager<CustomIdentityUser> _signInManager;
        private readonly ICustomIdentityDal _customIdentityDal;
        private readonly IConfiguration _configuration;
       

        public IdentityController(UserManager<CustomIdentityUser> userManager, SignInManager<CustomIdentityUser> signInManager, ICustomIdentityDal customIdentityDal, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _customIdentityDal = customIdentityDal;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            CustomIdentityUser user = new CustomIdentityUser
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Name = dto.Name

            };

            var result = await _userManager.CreateAsync(user,dto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            else
            {
                await _signInManager.SignInAsync(user,isPersistent: false);
                return Ok(result.Succeeded);
            }

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, false, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(loginDto.UserName);
                var userPole = await _userManager.GetRolesAsync(user);

                var loginClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),

                };

                foreach (var role in userPole)
                {
                    loginClaims.Add(new Claim(ClaimTypes.Role, role));
                    
                }

                var token = GetToken(loginClaims);

                var testToken = new { Token = new JwtSecurityTokenHandler().WriteToken(token),Expiration = token.ValidTo };

                return Ok(new { result, testToken });

            }

            return Ok("not found in JWT token ");
        }


        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var key = _configuration["Jwt:Key"];
            if (string.IsNullOrEmpty(key))
            {
                throw new InvalidOperationException("JWT Key is missing in the configuration.");
            }

            var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                expires: DateTime.UtcNow.AddHours(12),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
            );

            return token;
        }
    }
}
