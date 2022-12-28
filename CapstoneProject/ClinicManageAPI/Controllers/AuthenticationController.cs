using BusinessObject.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System;
using ClinicManageAPI.DTO;
using System.Linq;
using AutoMapper;
using BusinessObject;

namespace ClinicManageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public AuthenticationController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IMapper mapper, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _mapper = mapper;
            _context = context;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByNameAsync(loginDTO.UserName);
            if (user == null) return BadRequest("Wrong Username or Password");

            // var result = await _signInManager.PasswordSignInAsync(check,loginDTO.Password,false,false);
            var result = await _userManager.CheckPasswordAsync(user, loginDTO.Password);
            if (!result)
            {
                return BadRequest("Wrong Username or Password");
            }
            var roles = await _userManager.GetRolesAsync(user);
            //Generate Token
            var claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.FullName),
                    new Claim("Id",user.Id),
                    new Claim(ClaimTypes.Role,roles.LastOrDefault())
                };
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:Key"]);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Audience = _configuration["JWT:Audience"],
                Issuer = _configuration["JWT:Issuer"],
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescription);

            string role = new Claim(ClaimTypes.Role, roles.LastOrDefault()).ToString();

            string[] processsingString = role.Split("role: ");

            role = processsingString[1].ToString();

            return Ok(new LoginResponse
            {
                Token = tokenHandler.WriteToken(token),
                Id = user.Id,
                FullName = user.FullName,
                Role = role
            });
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            var user = _mapper.Map<User>(registerDTO);
            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Roles.Patient);
                string userId = user.Id;
                var patient = new Patient();
                patient.UserId = userId;
                _context.patients.Add(patient);
                _context.SaveChanges();
                return Ok("Create new account sucessfully");
            }

            return BadRequest(result);
        }
        public class LoginResponse
        {
            public string Token { get; set; }
            public string Id { get; set; }
            public string FullName { get; set; }
            public string Role { get; set; }
        }
    }
}
