using forum.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace forum.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IDiscussContext context;

        public CommentController(IDiscussContext context)
        {
                this.context = context;
        }

        [HttpGet]
        [Route("ReadComment/{id}")]

        public async Task<ActionResult<List<Comment>>> GetComment(int id)
        {
            var data = await context.Comments.Where(e => e.ThreadId == id).ToListAsync();
            return Ok(data);
        }

        [HttpPost]
        [Route("CreateComment")]
        public async Task<ActionResult<List<Comment>>> CreateComment(Comment comment)
        {
            var data = await context.Comments.AddAsync(comment);
            await context.SaveChangesAsync();
            return Ok(comment);
        }

        [HttpGet]
        [Route("GetComment")]

        public async Task<ActionResult<List<Comment>>> GetCategory()
        {
            var data = await context.Comments.ToListAsync();
            return Ok(data);
        }
    }
}
