using AutoMapper;
using BusinessObject;
using ClinicManageAPI.DTO;
using ClinicManageAPI.DTO.DoctorDtos;
using ClinicManageAPI.ServiceAPI.Paginations;
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
        public DoctorController(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// Get All Doctor
        /// </summary>
        /// <returns>Experience, Qualification and Infomation of Doctor</returns>
        [HttpGet("GetAllDoctor")]
        public async Task<IActionResult> GetAllDoctor([FromQuery] Pagination resultPage)
        {
            var doctor = await _context.doctors.Include(x => x.User).ToListAsync();
            var listDoctor = _mapper.ProjectTo<DoctorInfoDTO>(doctor.AsQueryable());
            var result = new PageList<DoctorInfoDTO>(listDoctor.AsQueryable(), resultPage.PageIndex, resultPage.PageSize);
            return Ok(result);
        }

        /// <summary>
        /// Input Name of Doctor
        /// </summary>
        /// <param name="name"></param>
        /// <returns>List Doctor if have any Doctor with same name</returns>
        [HttpGet("GetDoctorByName")]
        public async Task<IActionResult> GetDoctorByName(string name,[FromQuery] Pagination resultPage)
        {
            var doctor = await _context.doctors.Include(x => x.User)
                .Where(y => y.User.FirstName.Contains(name) || y.User.LastName.Contains(name))
                .ToListAsync();
            var listDoctor = _mapper.ProjectTo<DoctorInfoDTO>(doctor.AsQueryable());
            var result = new PageList<DoctorInfoDTO>(listDoctor.AsQueryable(), resultPage.PageIndex, resultPage.PageSize);
            return Ok(result);
        }
    }
}
