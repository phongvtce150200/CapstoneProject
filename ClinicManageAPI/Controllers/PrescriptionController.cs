using AutoMapper;
using BusinessObject;
using BusinessObject.Entity;
using ClinicManageAPI.DTO.PrescriptionDetailDtos;
using ClinicManageAPI.DTO.PrescriptionDtos;
using ClinicManageAPI.Extentions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicManageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PrescriptionController(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;   
            _context = context;
        }

        [HttpGet("GetAllPrescriptions")]
        public async Task<IActionResult> GetAllPrescriptions()
        {
            var prescriptions = await _context.prescriptions.Include(p => p.PrescriptionDetails).ToListAsync();
            if (prescriptions == null) return BadRequest("Don't have any prescriptions");
            var listPrescription = _mapper.ProjectTo<PrescriptionsDTO>(prescriptions.AsQueryable()).AsNoTracking().ToList();  
            
            return Ok(listPrescription);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrescription(int id)
        {
            var find = await _context.prescriptions.FindAsync(id);

            if (find == null)
            {
                return NotFound();
            }
            var prescription = _mapper.Map<PrescriptionsDTO>(find);

            return Ok(prescription);
        }

        [HttpGet("GetAllPrescriptionsByDoctor")]
        public async Task<IActionResult> GetAllPrescriptionsByDoctor(string name)
        {
            try
            {
                var listUser = await _context.Users.Where(x => x.FirstName.Contains(name.ToLower())).ToListAsync();
                var listDoctor = await _context.doctors.Where(x => listUser.Select(d => d.Id).Contains(x.UserId)).ToListAsync();
                var prescriptions = await _context.prescriptions.Include(p => p.Appointment).Include(c => c.PrescriptionDetails).Where(x => listDoctor.Select(d => d.Id).Contains(x.Appointment.DoctorId)).ToListAsync();
                if (prescriptions == null) return BadRequest("Don't have any prescriptions");
                var listPrescription = _mapper.Map<PrescriptionsDTO[]>(prescriptions.ToArray());

                return Ok(listPrescription);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }      
        }

        [HttpPost]
        public async Task<ActionResult<Prescription>> PostPrescription(int id, string descriptionIn, List<PrescriptionDetailDTO> prescriptionDetailDTO)
        {
            try
            {
                // Create  and add new prescription
                PrescriptionsDTO prescriptionDTO = new PrescriptionsDTO();
                prescriptionDTO.AppointmentId = id;
                var prescription = _mapper.Map<Prescription>(prescriptionDTO);
                var user = User.Identity.Name != null ? User.Identity.Name : "Anonymous";
                await _context.prescriptions.AddAsync(prescription.PostPrescription(user));

                // Create and add new prescription detail
                prescription.PrescriptionDetails = new List<PrescriptionDetails>();
                foreach (var item in prescriptionDetailDTO)
                {
                    var prescriptiondetail = _mapper.Map<PrescriptionDetails>(item);
                    prescription.PrescriptionDetails.Add(prescriptiondetail);
                    await _context.prescriptionDetails.AddAsync(prescriptiondetail);
                }

                // Create and add new invoice
                Invoice invoice = new Invoice();
                invoice.Description = descriptionIn;
                invoice.Prescription = prescription;
                await _context.invoices.AddAsync(invoice.PostInvoice(user));
                await _context.SaveChangesAsync();

                // Custome result
                var app = _context.appointments.Where(x => x.Id == id).FirstOrDefault();
                
                PrescriptionInfoDTO result = new PrescriptionInfoDTO();
                result.IdDoctor = app.DoctorId;
                result.IdPatient = app.PatientId;
                result.CreateDate = (System.DateTime)prescription.CreatedDate;
                result.PrescriptionDetails = new List<PrescriptionDetails>();
                foreach (var item in prescriptionDetailDTO)
                {
                    var listpsdt = _mapper.Map<PrescriptionDetails>(item);
                    result.PrescriptionDetails.Add(listpsdt);
                }


                    return Ok(result);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}
