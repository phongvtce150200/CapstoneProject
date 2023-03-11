using AutoMapper;
using BusinessObject;
using BusinessObject.Entity;
using ClinicManageAPI.DTO;
using ClinicManageAPI.DTO.DoctorDtos;
using ClinicManageAPI.DTO.NurseDtos;
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
    public class NurseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public NurseController(IMapper mapper, ApplicationDbContext context, UserManager<User> userManager)
        {
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
        }

        [HttpGet("GetAllNurse")]
        public async Task<IActionResult> GetAllNurse(/*[FromQuery] Pagination resultPage*/)
        {
            var nurse = await _context.nurses.Include(x => x.User).ToListAsync();
            var listNurse = _mapper.ProjectTo<NurseInfoDTO>(nurse.AsQueryable());
            //var result = new PageList<NurseInfoDTO>(listNurse.AsQueryable(), resultPage.PageIndex, resultPage.PageSize);
            return Ok(listNurse);
        }

        [HttpGet("GetNurseByName")]
        public async Task<IActionResult> GetNurseByName(string name/*, [FromQuery] Pagination resultPage*/)
        {
            var nurse = await _context.nurses.Include(x => x.User)
                .Where(y => y.User.FirstName.Contains(name) || y.User.LastName.Contains(name))
                .ToListAsync();
            var listNurse = _mapper.ProjectTo<NurseInfoDTO>(nurse.AsQueryable());
            //var result = new PageList<NurseInfoDTO>(listNurse.AsQueryable(), resultPage.PageIndex, resultPage.PageSize);
            return Ok(listNurse);
        }

        [HttpGet("GetNurseByNurseId/{id}")]
        public async Task<IActionResult> GetNurseByNurseId(int id)
        {
            // Find the nurse with the given id from the context
            var nurse = await _context.nurses.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);

            // If there is no nurse with the given id, return a NotFound status code
            if (nurse == null)
                return NotFound();

            // Map the found nurse to the NurseInfoDTO using AutoMapper
            var nurseInfo = _mapper.Map<NurseInfoDTO>(nurse);

            // Return the mapped nurse information
            return Ok(nurseInfo);
        }
        [HttpPost]
        public async Task<IActionResult> CreateNurse(CreateNurseDTO createNurseDTO)
        {
            var createUser = User.Identity.Name != null ? User.Identity.Name : "Anonymous";
            var user = _mapper.Map<User>(createNurseDTO);
            var result = await _userManager.CreateAsync(user, createNurseDTO.Password);
            user.CreateUser(createUser);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Roles.Nurse);
                //CHÕ NÀY ADMIN TẠO NÊN LÀ CHO MAIL CONFRIM LUÔN
                _context.SaveChanges();
                return Ok("Create new account sucessfully");
            }

            return BadRequest(result);
        }
        [HttpPut("DeleteNurse")]
        public async Task<IActionResult> DeleteNurse(int NurseId)
        {
            var nurse = await _context.nurses.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == NurseId);
            if (nurse is null)
            {
                return BadRequest("No Nurse was found");
            }
            var user = User.Identity.Name != null ? User.Identity.Name : "Anonymous";
            _context.Users.Update(nurse.User.DeleteUser(user));
            _context.SaveChanges();
            return Ok("Delete Nurse " + nurse.User.FullName + " Successfully");
        }
        [HttpPut("RestoreNurse")]
        public async Task<IActionResult> RestoreNurse(int NurseId)
        {
            var nurse = await _context.nurses.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == NurseId);
            if (nurse is null)
            {
                return BadRequest("No Nurse was found");
            }
            var user = User.Identity.Name != null ? User.Identity.Name : "Anonymous";
            _context.Users.Update(nurse.User.RestoreUser(user));
            _context.SaveChanges();
            return Ok("Restore Nurse " + nurse.User.FullName + " Successfully");
        }

        [HttpPut("EditNurse")]
        public async Task<IActionResult> EditNurse(int id, EditNurseDTO editNurseDTO)
        {
            var getNurse = await _context.nurses.FindAsync(id);
            try
            {
                if (getNurse is null)
                {
                    return BadRequest("No Nurse was found");
                }
                _mapper.Map(editNurseDTO, getNurse);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }


            return Ok("Update nurse  " + getNurse.User.FullName + " Successful");
        }

    }
}
