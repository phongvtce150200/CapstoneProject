using AutoMapper;
using BusinessObject;
using ClinicManageAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NurseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public NurseController(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("GetAllDoctor")]
        public async Task<IActionResult> GetAllNurse()
        {
            var nurse = await _context.nurses.Include(x => x.User).ToListAsync();
            var listNurse = _mapper.ProjectTo<NurseInfoDTO>(nurse.AsQueryable());
            return Ok(listNurse);
        }

        [HttpGet("GetDoctorByName")]
        public async Task<IActionResult> GetNurseByName(string name)
        {
            var nurse = await _context.nurses.Include(x => x.User)
                .Where(y => y.User.FirstName.Contains(name) || y.User.LastName.Contains(name))
                .ToListAsync();
            var listNurse = _mapper.ProjectTo<NurseInfoDTO>(nurse.AsQueryable());
            return Ok(listNurse);
        }
    }
}
