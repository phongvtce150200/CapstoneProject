using AutoMapper;
using BusinessObject.Entity;
using BusinessObject;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ClinicManageAPI.DTO.UserDtos;
using System.Threading.Tasks;
using ClinicManageAPI.Extentions;

namespace ClinicManageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public UserController(ApplicationDbContext context, UserManager<User> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }


        [HttpGet("{id}")]
        public IActionResult GetUserById(string id)
        {
            var user = _context.Users
            .Join(_context.UserRoles, u => u.Id, ur => ur.UserId, (u, ur) => new { u, ur })
            .Join(_context.Roles, ur => ur.ur.RoleId, r => r.Id, (ur, r) => new { ur, r })
            .ToList()
            .GroupBy(uv => new
            {
                uv.ur.u.UserName,
                uv.ur.u.Email,
                uv.ur.u.PhoneNumber,
                uv.ur.u.Id,
                uv.ur.u.FullName,
                uv.ur.u.FirstName,
                uv.ur.u.LastName,
                uv.ur.u.Gender,
                uv.ur.u.BirthDay,
                uv.ur.u.Address
            }).Select(r => new UserDTO()
            {
                Id = r.Key.Id,
                UserName = r.Key.UserName,
                FullName = r.Key.FullName,
                FirstName = r.Key.FirstName,
                LastName = r.Key.LastName,
                Gender = r.Key.Gender.ToString(),
                Email = r.Key.Email,
                PhoneNumber = r.Key.PhoneNumber,
                BirthDay = r.Key.BirthDay.ToShortDateString(),
                Address = r.Key.Address,
                Role = string.Join(",", r.Select(c => c.r.Name).ToArray())
            }).ToList().FirstOrDefault(u => u.Id == id);
            if (user == null) return BadRequest("User is Invalid");
            return Ok(user);
        }

        // DELETE api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return BadRequest("User is Invalid");
            var userDelete = User.Identity.Name != null ? User.Identity.Name : "Anonymous";
            _context.Users.Update(user.DeleteUser(userDelete));
            _context.SaveChanges();
            return Ok(user);
        }
    }
}
