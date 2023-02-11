using AutoMapper;
using BusinessObject;
using BusinessObject.Entity;
using ClinicManageAPI.DTO.QueueDtos;
using ClinicManageAPI.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        IHubContext<SignalRHub> _signalRServer;

        public QueueController(ApplicationDbContext context, IMapper mapper, IHubContext<SignalRHub> signalRServer)
        {
            _context = context;
            _mapper = mapper;
            _signalRServer = signalRServer;
        }

        [HttpGet]
        public async Task<IActionResult> GetQueue(int doctorId)
        {
            var queue = await _context.queues.Where(x => x.DoctorId == doctorId)
                .Include(x => x.Patient).ThenInclude(y => y.User)
                .Include(xx => xx.Doctor).ThenInclude(yy => yy.User)
                .OrderBy(y => y.Id).ToListAsync();
            var listQueue = _mapper.ProjectTo<GetQueueDTO>(queue.AsQueryable());
            // await _signalRServer.Clients.All.SendAsync("LoadQueue", listQueue);
            return Ok(listQueue);
        }

        [HttpPost]
        public async Task<ActionResult<Queue>> PostQueue(QueueDTO queueDTO)
        {
            var queue = _mapper.Map<Queue>(queueDTO);
            _context.queues.Add(queue);
            await _context.SaveChangesAsync();
            await _signalRServer.Clients.All.SendAsync("ReceiveQueue");
            return Ok();
        }
    }
}
