using AutoMapper;
using BusinessObject;
using ClinicManageAPI.DTO.AppointmentDtos;
using ClinicManageAPI.DTO.ReservedScheduleDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservedSchedulesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ReservedSchedulesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        // GET: api/ReservedSchedules
       /* [HttpGet]
        public async Task<IActionResult> GetReservedSchedules(*//*[FromQuery] Pagination resultPage*//*)
        {
            var schedules = await _context.reservedSchedules.ToListAsync();
            var schedule = _mapper.ProjectTo<ReservedScheduleDTO>(schedules.AsQueryable());
            //var result = new PageList<ReservedScheduleDTO>(schedule.AsQueryable(), resultPage.PageIndex, resultPage.PageSize);
            return Ok(schedule);
        }*/

        // GET: api/ReservedSchedules/5
       /* [HttpGet("{id}")]
        public async Task<ActionResult<ReservedSchedule>> GetReservedSchedule(int id)
        {
            var reservedSchedule = await _context.reservedSchedules.FindAsync(id);

            if (reservedSchedule == null)
            {
                return NotFound();
            }

            return reservedSchedule;
        }*/

        // PUT: api/ReservedSchedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
      /*  [HttpPut("{id}")]
        public async Task<IActionResult> PutReservedSchedule(int id, ReservedScheduleDTO reservedSchedule)
        {
            if (id != reservedSchedule.Id)
            {
                return BadRequest();
            }

            _context.Entry(reservedSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservedScheduleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }*/

        // POST: api/ReservedSchedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // Check if there is a booked slot in DB system will not create, otherwise it will create new booked slot.
        /*[HttpPost]
        public IActionResult PostReservedSchedule(ReservedScheduleDTO reservedSchedule)
        {
            var list = GetByDocId(reservedSchedule.DocId);
            var booked = list.Result.Value.FirstOrDefault(x => x.Start == reservedSchedule.Start);
            if (booked != null)
                return BadRequest();
            var schedule = _mapper.Map<ReservedSchedule>(reservedSchedule);
            _context.reservedSchedules.Add(schedule);
            _context.SaveChangesAsync();
            return Ok(schedule);
        }
*/
        // DELETE: api/ReservedSchedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservedSchedule(int id)
        {
            var reservedSchedule = await _context.reservedSchedules.FindAsync(id);
            if (reservedSchedule == null)
            {
                return NotFound();
            }

            _context.reservedSchedules.Remove(reservedSchedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        //Get a work schedule of a doctor 
        [HttpGet("DocId/{DocId}")]
        public async Task<IActionResult> GetAllScheduleByDocId(int DocId)
        {
            try
            {
                //var reservedSchedule = await _context.appointments.Where(x => x.DoctorId == DocId).Include(y => y.Schedule).ToListAsync();
                var reservedSchedule = await _context.reservedSchedules.Include(x => x.Appointment).Where(x => x.Appointment.DoctorId == DocId).ToListAsync();
                var map = _mapper.ProjectTo<ReservedScheduleInfoDTO>(reservedSchedule.AsQueryable());
                if (reservedSchedule.Count <= 0)
                {
                    return NotFound();
                }
                return Ok(map);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
           
        }
        private bool ReservedScheduleExists(int id)
        {
            return _context.reservedSchedules.Any(e => e.Id == id);
        }
    }
}
