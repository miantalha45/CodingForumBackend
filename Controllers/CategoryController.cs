using forum.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace forum.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IDiscussContext context;

        public CategoryController(IDiscussContext context) {
            this.context = context;
        }

        [HttpGet]
        [Route("ReadCategory")]

        public async Task<ActionResult<List<Category>>> GetCategory()
        {
            var data = await context.Categories.ToListAsync();
            return Ok(data);
        }

        [HttpGet]
        [Route("ReadCategory/{id}")]

        public async Task<ActionResult<List<Category>>> GetCategoryById(int id)
        {
            var student = await context.Categories.FindAsync(id);
            
            if(student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpGet]
        [Route("Read")]
        public async Task<ActionResult<List<Category>>> ReadCategory()
        {
            try
            {
                var data = await context.Categories.Take(5).ToListAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            }
        }

    }
}
