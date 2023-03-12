using AutoMapper;
using BusinessObject;
using BusinessObject.Entity;
using ClinicManageAPI.DTO;
using ClinicManageAPI.DTO.NurseDtos;
using ClinicManageAPI.DTO.PatientDtos;
using ClinicManageAPI.DTO.UserDtos;
using ClinicManageAPI.Extentions;
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
        public async Task<IActionResult> GetAllPatient(/*, [FromQuery] Pagination resultPage*/)
        {
            var user = await _context.patients.Include(x => x.User).ToListAsync();
            if (user == null) return BadRequest("Don't have any User with role Patient");
            var listPatient = _mapper.ProjectTo<PatientDTO>(user.AsQueryable()).AsNoTracking().ToList();
            /*var result = new PageList<PatientDTO>(Patient.AsQueryable()/*, resultPage.PageIndex, resultPage.PageSize);*/
            return Ok(listPatient);
        }

        [HttpGet("GetPatientByName")]
        public async Task<IActionResult> GetPatientByName(string name/*, [FromQuery] Pagination resultPage*/)
        {
            var user = await _context.patients.Include(x => x.User).ToListAsync();
            if (user == null) return BadRequest("Don't have any User with role Patient");
            var listPatient = _mapper.ProjectTo<PatientDTO>(user.AsQueryable()
                .Where(x => x.User.FullName.ToLower().Contains(name))).AsNoTracking().ToList();
            /*var result = new PageList<PatientDTO>(Patient.AsQueryable()/*, resultPage.PageIndex, resultPage.PageSize);*/
            return Ok(listPatient);
        }
        [HttpGet("GetPatientById")]
        public async Task<IActionResult> GetPatientById(int id/*, [FromQuery] Pagination resultPage*/)
        {
            var user = await _context.patients.Include(x => x.User).ToListAsync();
            if (user == null) return BadRequest("Don't have any User with role Patient");
            var Patient =  _mapper.ProjectTo<PatientDTO>(user.AsQueryable().Where(x => x.Id == id)).FirstOrDefault();
            /*var result = new PageList<PatientDTO>(Patient.AsQueryable()/*, resultPage.PageIndex, resultPage.PageSize);*/
            return Ok(Patient);
        }
        [HttpPut("DeletePut")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = await _context.patients.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
            if (patient is null)
            {
                return BadRequest("No Patient was found");
            }
            var user = User.Identity.Name != null ? User.Identity.Name : "Anonymous";
            _context.Users.Update(patient.User.DeleteUser(user));
            _context.SaveChanges();
            return Ok("Delete Nurse " + patient.User.FullName + " Successfully");
        }
        [HttpPut("RestorePatient")]
        public async Task<IActionResult> RestorePatient(int id)
        {
            var patient = await _context.patients.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
            if (patient is null)
            {
                return BadRequest("No Patient was found");
            }
            var user = User.Identity.Name != null ? User.Identity.Name : "Anonymous";
            _context.Users.Update(patient.User.RestoreUser(user));
            _context.SaveChanges();
            return Ok("Restore Nurse " + patient.User.FullName + " Successfully");
        }

        [HttpPut("EditPatientInfomation/{id}")]
        public async Task<IActionResult> EditPatientInfomation(int id,EditUserDTO editUserDTO)
        {
            var check = await _context.Users.Include(x => x.Patient).Where(x => x.Patient.Id == id).FirstOrDefaultAsync();
            if(check is null)
            {
                return NotFound("User invalid");
            }
            _mapper.Map(editUserDTO, check);
            await _context.SaveChangesAsync();
            return Ok("Edit User Successfully");
        } 
    }
}
