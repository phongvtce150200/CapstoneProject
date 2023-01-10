using AutoMapper;
using BusinessObject;
using ClinicManageAPI.DTO;
using ClinicManageAPI.ServiceAPI.Pagination;
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

        [HttpGet("GetAllNurse")]
        public async Task<IActionResult> GetAllNurse([FromQuery] Pagination resultPage)
        {
            var nurse = await _context.nurses.Include(x => x.User).ToListAsync();
            var listNurse = _mapper.ProjectTo<NurseInfoDTO>(nurse.AsQueryable());
            var result = new PageList<NurseInfoDTO>(listNurse.AsQueryable(), resultPage.PageIndex, resultPage.PageSize);
            return Ok(result);
        }

        [HttpGet("GetNurseByName")]
        public async Task<IActionResult> GetNurseByName(string name, [FromQuery] Pagination resultPage)
        {
            var nurse = await _context.nurses.Include(x => x.User)
                .Where(y => y.User.FirstName.Contains(name) || y.User.LastName.Contains(name))
                .ToListAsync();
            var listNurse = _mapper.ProjectTo<NurseInfoDTO>(nurse.AsQueryable());
            var result = new PageList<NurseInfoDTO>(listNurse.AsQueryable(), resultPage.PageIndex, resultPage.PageSize);
            return Ok(result);
        }
    }
}
