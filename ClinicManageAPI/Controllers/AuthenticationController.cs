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
using System.Linq;
using AutoMapper;
using BusinessObject;
using Newtonsoft.Json.Linq;
using System.Data;
using ClinicManageAPI.Respone;
using ClinicManageAPI.Helper;
using Microsoft.AspNetCore.Authorization;
using ClinicManageAPI.DTO.AuthenticationDtos;
using ClinicManageAPI.DTO;
using ClinicManageAPI.Extentions;

namespace ClinicManageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
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

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="loginDTO"></param>
        /// <returns>Token and Infomation of User</returns>
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

        
            var getDoctorId = _context.doctors.FirstOrDefault(x => x.UserId == user.Id);
            var getNurseId  = _context.nurses.FirstOrDefault(x => x.UserId == user.Id);
            
            if(getDoctorId == null && getNurseId == null)
            {
                return Ok(new LoginResponse
                {
                    Token = tokenHandler.WriteToken(token),
                    Id = user.Id,
                    FullName = user.FullName,
                    Role = role
                });
            }
            if(getDoctorId != null)
            {
                return Ok(new LoginDoctorResponse
                {
                    Token = tokenHandler.WriteToken(token),
                    Id = user.Id,
                    FullName = user.FullName,
                    Role = role,
                    DoctorId = getDoctorId.Id,
                });
            }  
            if(getNurseId != null)
            {
                return Ok(new LoginNurseResponse
                {
                    Token = tokenHandler.WriteToken(token),
                    Id = user.Id,
                    FullName = user.FullName,
                    Role = role,
                    NurseId = getNurseId.Id,
                });
            }
            return BadRequest();
        }

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="registerDTO"></param>
        /// <returns>Success if create succesfully, otherwise</returns>
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            var user = _mapper.Map<User>(registerDTO);
            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Roles.Patient);
                var createUser = User.Identity.Name != null ? User.Identity.Name : "Anonymous";
                user.CreateUser(createUser);
                string userId = user.Id;
                var patient = new Patient();
                patient.UserId = userId;
                _context.patients.Add(patient);
                _context.SaveChanges();

                string code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = Request.Scheme + "://" + Request.Host + Url.Action("ConfirmMail", "Authentication",
                    new { usermail = user.Email, code = code });
                string htmlBody = "<html><body>Please confirm your account by clicking <a href='" + callbackUrl + "'>Click this link</a></body></html>";
                SendMail.SendEmail(user.Email, "Confirm Your Email Account", htmlBody, "");

                return Ok("Create new account sucessfully");
            }

            return BadRequest(result);
        }

        /// <summary>
        /// Confirm email
        /// </summary>
        /// <param name="usermail"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet("ConfirmMail")]
        public async Task<IActionResult> ConfirmMail(string usermail, string code)
        {
            var user = await _userManager.FindByEmailAsync(usermail);
            if (user != null)
            {

                var result = await _userManager.ConfirmEmailAsync(user, code);
                if (result.Succeeded) 
                return Ok("Email has been Confirm");

            }

            return BadRequest("Something went wrong");
        }

        /// <summary>
        /// Request token to confirm email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet("RequestConfirmEmail")]
        public async Task<IActionResult> RequestConfirmEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return BadRequest("Your account has not been exits");
            }

            string code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Request.Scheme + "://" + Request.Host + Url.Action("ConfirmMail", "Authentication",
                new { usermail = user.Email, code = code });
            string htmlBody = "<html><body>Please confirm your account by clicking <a href='" + callbackUrl + "'>Click this link</a></body></html>";
            SendMail.SendEmail(user.Email, "Confirm Your Email Account", htmlBody, ""); 
            return Ok("Email has been sent");
        }

        [HttpPost("RequestResetPassword")]
        public async Task<IActionResult> RequestResetPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return BadRequest("Couldn't find any accounts associated with this email");
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackUrl = "http://localhost:8080/resetpassword/" + token;
            string htmlBody = "<html><body>Please confirm your account by clicking <a href='" + callbackUrl + "'>Click this link</a></body></html>";
            SendMail.SendEmail(user.Email, "Reset Password", "Your password reset code is: " + htmlBody, "");

            return Ok(token);
        }

        [HttpGet("GetResetPassword")]
        public ResetPasswordDTO GetResetPasswordModel(string email, string token)
        {
            ResetPasswordDTO rpDTO = new ResetPasswordDTO();
            rpDTO.token = token;
            rpDTO.email = email;
            return rpDTO;
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> GetResetPassword(string email, string newpw, string pwconfirm, string fulltoken)
        {
            var user = await _userManager.FindByEmailAsync(email);
            int tokenLenght = fulltoken.ToString().Length;
            int indexOfLastChar = fulltoken.ToString().LastIndexOf('+');
            string subToken1 = fulltoken.ToString().Substring(0, indexOfLastChar);
            
            string subToken3 = fulltoken.ToString().Substring(indexOfLastChar + 7);
            //string token = subToken1 + stoken + subToken3;
            if (user == null)
            {
                return BadRequest("Couldn't find account");
            }
            if(newpw.Equals(pwconfirm) == false)
            {
                return BadRequest("Password Confirm dose not matching");
            }
            var result = await _userManager.ResetPasswordAsync(user, fulltoken, newpw);
            if(!result.Succeeded)
            {
                return BadRequest("Some thing went wrong");
            }
            return Ok("Password has been changed");
            
        }


    }
}
