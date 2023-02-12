using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using BusinessObject.Entity;
using AutoMapper;
using ClinicManageAPI.DTO;
using ClinicManageAPI.ServiceAPI.Paginations;
using ClinicManageAPI.Extentions;
using ClinicManageAPI.DTO.MedicineDtos;

namespace ClinicManageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MedicinesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Medicines
        /// <summary>
        /// Get all Medicine
        /// </summary>
        /// <returns>List Medicine</returns>
        [HttpGet("GetAllMedicines")]
        public async Task<IActionResult> GetAllMedicines([FromQuery] Pagination resultPage)
        {
            var medicine = await _context.medicines.ToListAsync();
            var listMedicine = _mapper.ProjectTo<MedicineDTO>(medicine.AsQueryable());
            var result = new PageList<MedicineDTO>(listMedicine.AsQueryable(), resultPage.PageIndex, resultPage.PageSize);
            return Ok(result);
        }

        // GET: api/Medicines/5
        /// <summary>
        /// Get 1 medicine with Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Medicine</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicine(int id)
        {
            var find = await _context.medicines.FindAsync(id);

            if (find == null)
            {
                return NotFound();
            }
            var medicine = _mapper.Map<CreateMedicineDTO>(find);

            return Ok(medicine);
        }

        // PUT: api/Medicines/5
        /// <summary>
        /// Input Id Medicine need Edit
        /// </summary>
        /// <param name="id"></param>
        /// <param name="medicineDTO"></param>
        /// <returns>return Ok if edit successfuly, otherwise</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicine(int id, EditMedicineDTO medicineDTO)
        {
            if (id != medicineDTO.Id)
            {
                return BadRequest();
            }
            var find = _context.medicines.Find(id);
            var user = User.Identity.Name != null ? User.Identity.Name : "Anonymous";
            var medicine = _mapper.Map<EditMedicineDTO, Medicine>(medicineDTO, find);
            _context.Entry(medicine.UpdateMedicine(user)).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicineExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(medicine);
        }

        // POST: api/Medicines
        /// <summary>
        /// Input Medicine Object
        /// </summary>
        /// <param name="medicineDTO"></param>
        /// <returns>return Ok if create successfuly, otherwise</returns>
        [HttpPost]
        public async Task<ActionResult<Medicine>> PostMedicine(CreateMedicineDTO medicineDTO)
        {
            var medicine = _mapper.Map<Medicine>(medicineDTO);
            var user = User.Identity.Name != null ? User.Identity.Name : "Anonymous";    
                await _context.medicines.AddAsync(medicine.PostMedicine(user));
                await _context.SaveChangesAsync();
       
            return CreatedAtAction("GetMedicine", new { id = medicine.Id }, medicine);
        }

        // DELETE: api/Medicines/5
        /// <summary>
        /// Input Id of medicine 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>return NoContent if delete succesfully, otherwise</returns>
        [HttpPut("DeleteMedicine/{id}")]
        public async Task<IActionResult> DeleteMedicine(int id)
        {
            var medicine = await _context.medicines.FindAsync(id);
            if (medicine == null)
            {
                return NotFound();
            }
            var user = User.Identity.Name != null ? User.Identity.Name : "Anonymous";
            _context.medicines.Update(medicine.DeleteMedicine(user));
            await _context.SaveChangesAsync();

            return Ok(medicine);
        }
        [HttpPut("RestoreMedicne")]
        public async Task<IActionResult> RestoreMedicine(int id)
        {
            var medicine = await _context.medicines.FindAsync(id);
            if(medicine == null)
            {
                return NotFound();
            }
            var user = User.Identity.Name != null ? User.Identity.Name : "Anonymous";
            _context.medicines.Update(medicine.RestoreDeleteMedicine(user));
            await _context.SaveChangesAsync();
            return Ok(medicine);
        }

        private bool MedicineExists(int id)
        {
            return _context.medicines.Any(e => e.Id == id);
        }
    }
}
