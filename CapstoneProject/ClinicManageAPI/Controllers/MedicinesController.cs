using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject;
using BusinessObject.Entity;
using AutoMapper;
using ClinicManageAPI.DTO;

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
        [HttpGet]
        public async Task<IActionResult> Getmedicines()
        {
            var medicine = await _context.medicines.ToListAsync();
            var listMedicine = _mapper.ProjectTo<MedicineDTO>(medicine.AsQueryable());
            return Ok(listMedicine);
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
            var medicine = _mapper.Map<MedicineDTO>(find);

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
        public async Task<IActionResult> PutMedicine(int id, MedicineDTO medicineDTO)
        {
            if (id != medicineDTO.Id)
            {
                return BadRequest();
            }
            var find = _context.medicines.Find(id);
            var medicine = _mapper.Map<MedicineDTO, Medicine>(medicineDTO, find);
            _context.Entry(medicine).State = EntityState.Modified;

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

            return NoContent();
        }

        // POST: api/Medicines
        /// <summary>
        /// Input Medicine Object
        /// </summary>
        /// <param name="medicineDTO"></param>
        /// <returns>return Ok if create successfuly, otherwise</returns>
        [HttpPost]
        public async Task<ActionResult<Medicine>> PostMedicine(MedicineDTO medicineDTO)
        {
            var medicine = _mapper.Map<Medicine>(medicineDTO);
            _context.medicines.Add(medicine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicine", new { id = medicine.Id }, medicine);
        }

        // DELETE: api/Medicines/5
        /// <summary>
        /// Input Id of medicine 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>return NoContent if delete succesfully, otherwise</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicine(int id)
        {
            var medicine = await _context.medicines.FindAsync(id);
            if (medicine == null)
            {
                return NotFound();
            }

            _context.medicines.Remove(medicine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedicineExists(int id)
        {
            return _context.medicines.Any(e => e.Id == id);
        }
    }
}
