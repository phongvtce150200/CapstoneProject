using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using BusinessObject.Entity;
using AutoMapper;
using ClinicManageAPI.DTO;
using ClinicManageAPI.ServiceAPI.Paginations;
using ClinicManageAPI.DTO.ServiceDtos;
using ClinicManageAPI.Extentions;

namespace ClinicManageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ServicesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Services
        [HttpGet]
        public async Task<IActionResult> GetAllServices(/*[FromQuery] Pagination resultPage*/)
        {
            var service = await _context.services.ToListAsync();
            var listService = _mapper.ProjectTo<ServiceDTO>(service.AsQueryable());
            //var result = new PageList<ServiceDTO>(listService.AsQueryable(), resultPage.PageIndex, resultPage.PageSize);
            return Ok(listService);
        }

        // GET: api/Services/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetService(int id)
        {
            var find = await _context.services.FindAsync(id);

            if (find == null)
            {
                return NotFound();
            }
            var service = _mapper.Map<ServiceDTO>(find);
            return  Ok(service);
        }

        // PUT: api/Services/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutService(int id, ServiceDTO serviceDTO)
        {
            if (id != serviceDTO.Id)
            {
                return BadRequest();
            }
            var find = _context.services.Find(id);
            var user = User.Identity.Name;
            var service = _mapper.Map<ServiceDTO, Service>(serviceDTO,find);
            _context.Entry(service.UpdateService(user)).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Services
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostService(ServiceDTO serviceDTO)
        {
            var user = User.Identity.Name;
            var service = _mapper.Map<Service>(serviceDTO);
            _context.services.Add(service.PostService(user));
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetService", new { id = service.Id }, service);
        }

        // DELETE: api/Services/5
        [HttpPut("DeleteService/{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var user = User.Identity.Name;
            var service = await _context.services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            _context.services.Update(service.DeleteService(user));
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceExists(int id)
        {
            return _context.services.Any(e => e.Id == id);
        }
    }
}
