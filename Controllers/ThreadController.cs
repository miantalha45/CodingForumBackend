using forum.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace forum.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThreadController : ControllerBase
    {
        private readonly IDiscussContext context;

        public ThreadController(IDiscussContext context)
        {
                this.context = context;
        }


        [HttpGet]
        [Route("ReadThread/{id}")]

        public async Task<ActionResult<List<Threads>>> GetThreads(int id)
        {
            var data = await context.Threads.FindAsync(id);
            return Ok(data);
        }

        [HttpGet]
        [Route("ReadThread/Catid/{id}")]

        public async Task<ActionResult<List<Threads>>> GetThreadbyCatid(int id)
        {
            var data = await context.Threads.Where(e => e.ThreadCatId == id).ToListAsync();
            return Ok(data);
        }

        [HttpPost]
        [Route("CreateRecord")]
        public async Task<ActionResult<Threads>> CreateThread(Threads std)
        {

            await context.Threads.AddAsync(std);
            await context.SaveChangesAsync();
            return Ok(std);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return BadRequest("Query is required");
            }
            var result = await context.Threads.Where(t => EF.Functions.Like(t.ThreadTitle, $"%{query}%") || EF.Functions.Like(t.ThreadDesc, $"%{query}%")).ToListAsync();

            if (result.Count == 0)
            {
                return NotFound("No results found");
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("GetThread")]

        public async Task<ActionResult<List<Thread>>> GetCategory()
        {
            var data = await context.Threads.ToListAsync();
            return Ok(data);
        }
    }
}
