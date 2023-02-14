using AutoMapper;
using BusinessObject;
using BusinessObject.Entity;
using ClinicManageAPI.DTO;
using ClinicManageAPI.DTO.PatientDtos;
using ClinicManageAPI.ServiceAPI.Paginations;
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
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PatientController(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("GetAllPatient")]
        public async Task<IActionResult> GetAllPatient([FromQuery] Pagination resultPage)
        {
            var user = await _context.patients.Include(x => x.User).ToListAsync();
            if (user == null) return BadRequest("Don't have any User with role Patient");
            var listPatient = _mapper.ProjectTo<PatientDTO>(user.AsQueryable()).AsNoTracking().ToList();
            var result = new PageList<PatientDTO>(listPatient.AsQueryable(), resultPage.PageIndex, resultPage.PageSize);
            return Ok(result);
        }

        [HttpGet("GetPatientByName")]
        public async Task<IActionResult> GetPatientByName(string name, [FromQuery] Pagination resultPage)
        {
            var user = await _context.patients.Include(x => x.User).ToListAsync();
            if (user == null) return BadRequest("Don't have any User with role Patient");
            var listPatient = _mapper.ProjectTo<PatientDTO>(user.AsQueryable()
                .Where(x => x.User.FullName.ToLower().Contains(name))).AsNoTracking().ToList();
            var result = new PageList<PatientDTO>(listPatient.AsQueryable(), resultPage.PageIndex, resultPage.PageSize);
            return Ok(result);
        }
        [HttpGet("GetPatientById")]
        public async Task<IActionResult> GetPatientById(int id, [FromQuery] Pagination resultPage)
        {
            var user = await _context.patients.ToListAsync();
            if (user == null) return BadRequest("Don't have any User with role Patient");
            var Patient = _mapper.ProjectTo<PatientDTO>(user.AsQueryable().Where(x => x.Id == id));
            var result = new PageList<PatientDTO>(Patient.AsQueryable(), resultPage.PageIndex, resultPage.PageSize);
            return Ok(result);
        }
    }
}
