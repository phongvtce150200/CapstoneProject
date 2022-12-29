using AutoMapper;
using BusinessObject;
using BusinessObject.Entity;
using ClinicManageAPI.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public PatientController(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet("GetAllPatient")]
        public async Task<IActionResult> GetAllPatient()
        {
            var user = await _userManager.GetUsersInRoleAsync("Patient");
            if (user == null) return BadRequest("Don't have any User with role Patient");
            var listPatient = _mapper.ProjectTo<UserInfoDTO>(user.AsQueryable()).AsNoTracking().ToList();
            return Ok(listPatient);
        }

        [HttpGet("GetPatientByName")]
        public async Task<IActionResult> GetPatientByName(string name)
        {
            var user = await _userManager.GetUsersInRoleAsync("Patient");
            if (user == null) return BadRequest("Don't have any User with role Patient");
            var listPatient = _mapper.ProjectTo<UserInfoDTO>(user.AsQueryable()
                .Where(x => x.FullName.ToLower().Contains(name))).AsNoTracking().ToList();
            return Ok(listPatient);
        }
    }
}
