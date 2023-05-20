using DMAWS_T2108E_KhongThiThuong.DbContextConnection;
using DMAWS_T2108E_KhongThiThuong.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DMAWS_T2108E_KhongThiThuong.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResultHere <Project>> GetProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        // PUT: api/Projects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, Project project)
        {
            if (id != project.ProjectId)
            {
                return BadRequest();
            }

            _context.Entry(project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
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

        // POST: api/Projects
        [HttpPost]
        public async Task<ActionResult<Project>> PostProject(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProject", new { id = project.ProjectId }, project);
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(projectHere);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.ProjectId == id);
        }

        //Search

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Project>>> SearchProjects(string projectName = null, bool? inProgress = null, bool? finished = null)
        {
            var query = _context.Projects.AsQueryable();

            if (!string.IsNullOrEmpty(projectName))
            {
                query = query.Where(p => p.ProjectName.Contains(projectName));
            }

            if (inProgress.HasValue && inProgress.Value)
            {
                query = query.Where(p => p.ProjectEndDate == null || p.ProjectEndDate > DateTime.Now);
            }

            if (finished.HasValue && finished.Value)
            {
                query = query.Where(p => p.ProjectEndDate != null && p.ProjectEndDate < DateTime.Now);
            }

            return await query.ToListAsyncHere);
        }

        [HttpGet("{id}/details")]
        public async Task<ActionResult<Project>> GetProjectDetails(int id)
        {
            var project = await _context.Projects.Include(p => p.ProjectEmployees).ThenInclude(pe => pe.Employees).FirstOrDefaultAsync(p => p.ProjectId == id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Employee>>> SearchEmployees(string employeeName = null, DateTime? dobFrom = null, DateTime? dobTo = null)
        {
            var query = _context.Employees.AsQueryable();

            if (!string.IsNullOrEmpty(employeeName))
            {
                query = query.Where(e => e.EmployeeName.Contains(employeeName));
            }

            if (dobFrom.HasValue)
            {
                query = query.Where(e => e.EmployeeDOB >= dobFrom.Value);
            }

            if (dobTo.HasValue)
            {
                query = query.Where(e => e.EmployeeDOB <= dobTo.Value);
            }

            return await query.ToListAsync();
        }


    }
}
