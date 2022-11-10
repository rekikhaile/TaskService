using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
//using System.Web.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TakeHomeCodingAssignment.Data;
using TakeHomeCodingAssignment.Models;
using TaskAppGeico.Models;

namespace TakeHomeCodingAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeicoTasksController : ControllerBase
    {
        private readonly GeicoTaskDbContext _context;

        public GeicoTasksController(GeicoTaskDbContext context)
        {
            _context = context;
        }

        // GET: api/GeicoTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeicoTask>>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        // GET: api/GeicoTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GeicoTask>> GetGeicoTask(int id)
        {
            var geicoTask = await _context.Tasks.FindAsync(id);

            if (geicoTask == null)
            {
                return NotFound();
            }

            return geicoTask;
        }

        // PUT: api/GeicoTasks/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeicoTask(int id, GeicoTask geicoTask)
        {
            if (id != geicoTask.Id)
            {
                return BadRequest();
            }

            _context.Entry(geicoTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeicoTaskExists(id))
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

        // POST: api/GeicoTasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GeicoTask>> PostGeicoTask(GeicoTask geicoTask)
        {

             /*  int count = _context.Tasks
                  .FromSqlRaw("SELECT * from GeicoTask where Priority = 1 AND Status <> 1 AND  DueDate ={0}", geicoTask.DueDate).Count();

            if (count > 100) {
                throw new SystemException("High Priority has exceeded limit");
            }*/
           
            
                

            _context.Tasks.Add(geicoTask);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetGeicoTask", new { id = geicoTask.Id }, geicoTask);
            
       


            return CreatedAtAction(nameof(GetGeicoTask), new { id = geicoTask.Id }, geicoTask);
        }

        // DELETE: api/GeicoTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGeicoTask(int id)
        {
            var geicoTask = await _context.Tasks.FindAsync(id);
            if (geicoTask == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(geicoTask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GeicoTaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
