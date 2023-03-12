using AutoMapper;
using BusinessObject;
using BusinessObject.Entity;
using ClinicManageAPI.DTO.AppointmentDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ClinicManageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AppointmentController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAppointmentById(int id)
        {
            var getAppointmentInfomation = await _context.appointments.Include(x => x.Patient).ThenInclude(x => x.User)
                .Include(y => y.Doctor).ThenInclude(y => y.User).FirstOrDefaultAsync();
            var map = _mapper.Map<GetInfoAppointmentDTO>(getAppointmentInfomation);
            JsonSerializerSettings jss = new JsonSerializerSettings();
            jss.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            string jsons = JsonConvert.SerializeObject(map, jss);
            return Content(jsons, "application/json");
            //return Ok(getAppointmentInfomation);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAppointment(CreateAppointmentDTO createAppointmentDTO)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<Appointment>(createAppointmentDTO);
                _context.appointments.Add(map);
                await _context.SaveChangesAsync();  
                return Ok("Create Appointment Successfully");    
            }
            return BadRequest("Create Appointment Fail");
        }
    }
}
