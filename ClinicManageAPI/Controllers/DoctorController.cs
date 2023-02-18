using AutoMapper;
using BusinessObject;
using BusinessObject.Entity;
using ClinicManageAPI.DTO.DoctorDtos;
using ClinicManageAPI.Extentions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public DoctorController(IMapper mapper, ApplicationDbContext context, UserManager<User> userManager)
        {
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
        }

        /// <summary>
        /// Get All Doctor
        /// </summary>
        /// <returns>Experience, Qualification and Infomation of Doctor</returns>
        [HttpGet("GetAllDoctor")]
        public async Task<IActionResult> GetAllDoctor(/*[FromQuery] Pagination resultPage*/)
        {
            var doctor = await _context.doctors.Include(x => x.User).ToListAsync();
            var listDoctor = _mapper.ProjectTo<DoctorInfoDTO>(doctor.AsQueryable());
            //var result = new PageList<DoctorInfoDTO>(listDoctor.AsQueryable(), resultPage.PageIndex, resultPage.PageSize);
            return Ok(listDoctor);
        }

        /// <summary>
        /// Input Name of Doctor
        /// </summary>
        /// <param name="name"></param>
        /// <returns>List Doctor if have any Doctor with same name</returns>
        [HttpGet("GetDoctorByName")]
        public async Task<IActionResult> GetDoctorByName(string name/*,[FromQuery] Pagination resultPage*/)
        {
            var doctor = await _context.doctors.Include(x => x.User)
                .Where(y => y.User.FirstName.Contains(name) || y.User.LastName.Contains(name))
                .ToListAsync();
            var listDoctor = _mapper.ProjectTo<DoctorInfoDTO>(doctor.AsQueryable());
            //var result = new PageList<DoctorInfoDTO>(listDoctor.AsQueryable(), resultPage.PageIndex, resultPage.PageSize);
            return Ok(listDoctor);
        }

        // HttpGet attribute defines the endpoint for the method
        [HttpGet("GetDoctorById")]
        public async Task<IActionResult> GetDoctorById(int doctorId)
        {
            // Find the doctor with the specified ID in the database
            var doctor = await _context.doctors
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == doctorId);

            // If doctor was not found, return NotFound result
            if (doctor == null)
            {
                return NotFound();
            }

            // Map the found doctor to a DoctorInfoDTO using AutoMapper
            var doctorDto = _mapper.Map<DoctorInfoDTO>(doctor);

            // Return the mapped doctor
            return Ok(doctorDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDoctor(CreateDoctorDTO createDoctorDTO)
        {
            var createUser = User.Identity.Name != null ? User.Identity.Name : "Anonymous";
            var user = _mapper.Map<User>(createDoctorDTO);
            var result = await _userManager.CreateAsync(user, createDoctorDTO.Password);
            user.CreateUser(createUser);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Roles.Doctor); 
                //CHÕ NÀY ADMIN TẠO NÊN LÀ CHO MAIL CONFRIM LUÔN
               
                _context.SaveChanges();



                return Ok("Create new account sucessfully");
            }

            return BadRequest(result);
        }
        [HttpPut("DeleteDoctor")]
        public async Task<IActionResult> DeleteDoctor(int DoctorId)
        {
            var doctor = await _context.doctors.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == DoctorId);
            if(doctor is null)
            {
                return BadRequest("No Doctor was found");
            }
            var user = User.Identity.Name != null ? User.Identity.Name : "Anonymous";
            _context.Users.Update(doctor.User.DeleteUser(user));
            _context.SaveChanges();
            return Ok("Delete Doctor " +doctor.User.FullName+ " Successfully");
        }
        [HttpPut("RestoreDoctor")]
        public async Task<IActionResult> RestoreDoctor(int DoctorId)
        {
            var doctor = await _context.doctors.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == DoctorId);
            if (doctor is null)
            {
                return BadRequest("No Doctor was found");
            }
            var user = User.Identity.Name != null ? User.Identity.Name : "Anonymous";
            _context.Users.Update(doctor.User.RestoreUser(user));
            _context.SaveChanges();
            return Ok("Restore Doctor " + doctor.User.FullName + " Successfully");
        }
    }
}
