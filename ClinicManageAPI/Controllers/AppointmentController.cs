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
        public async Task<IActionResult> GetAppointments()
        {
            var getAppointmentInfomation = await _context.appointments.ToListAsync();
            //var map = _mapper.Map<GetInfoAppointmentDTO>(getAppointmentInfomation);
            /*JsonSerializerSettings jss = new JsonSerializerSettings();
            jss.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            string jsons = JsonConvert.SerializeObject(map, jss);
            return Content(jsons, "application/json");*/
            return Ok(getAppointmentInfomation);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAppointment(CreateAppointmentDTO createAppointmentDTO)
        {
            if (ModelState.IsValid)
            {
                var map = _mapper.Map<Appointment>(createAppointmentDTO);
                await _context.appointments.AddAsync(map);
                await _context.SaveChangesAsync();  
                return Ok("Create Appointment Successfully");    
            }
            return BadRequest("Create Appointment Fail");
        }
    }
}
