using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
    private readonly AppDbContext _context;

    public PatientsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Patients
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
    {
        return await _context.Patients.ToListAsync();
    }

    // GET: api/Patients/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Patient>> GetPatient(int id)
    {
        var patient = await _context.Patients.FindAsync(id);

        if (patient == null)
        {
            return NotFound();
        }

        return patient;
    }

    // POST: api/Patients
    [HttpPost]
    public async Task<ActionResult<Patient>> PostPatient(Patient patient)
    {
        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPatient", new { id = patient.Id }, patient);
    }

    // PUT: api/Patients/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPatient(int id, Patient patient)
    {
        if (id == patient.Id)
        {
            _context.Entry(patient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(id))
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
        return BadRequest();
    }

    // DELETE: api/Patients/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePatient(int id)
    {
        var patient = await _context.Patients.FindAsync(id);
        if (patient == null)
        {
            return NotFound();
        }

        _context.Patients.Remove(patient);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PatientExists(int id)
    {
        return _context.Patients.Any(e => e.Id == id);
    }

    // POST: api/Patients/{patientId}/Visits
    [HttpPost("{patientId}/Visits")]
    public async Task<ActionResult<Visit>> CreateVisit(int patientId, Visit visit)
    {
        visit.PatientID = patientId;
        _context.Visits.Add(visit);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetVisit", new { id = visit.VisitID }, visit);
    }

    // GET: api/Patients/{patientId}/Visits
    [HttpGet("{patientId}/Visits")]
    public async Task<ActionResult<IEnumerable<Visit>>> GetVisitsForPatient(int patientId)
    {
        var visits = await _context.Visits
            .Where(v => v.PatientID == patientId)
            .ToListAsync();

        return visits;
    }
}
