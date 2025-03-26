using forum.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace forum.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDiscussContext context;
        public UserController(IDiscussContext context)
        {
                this.context = context;
        }

        [HttpPost]
        [Route("Signup")]
        public async Task<ActionResult<User>> Signup(User user)
        {

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpGet]
        [Route("ReadUser/email/{email}")]

        public async Task<ActionResult<List<User>>> GetUserbyEmail(string email)
        {
            var user = await context.Users.Where(e => e.UserEmail == email).ToListAsync();
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        [Route("ReadUser/{id}")]

        public async Task<ActionResult<List<User>>> GetUserbyId(int id)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<List<User>>> Login(User user)
        {
            var myUser = await context.Users.Where(e => e.UserEmail == user.UserEmail).FirstOrDefaultAsync();
            if(myUser != null)
            {
                HttpContext.Session.SetString("Username", myUser.UserName);
                HttpContext.Session.SetString("Useremail", myUser.UserEmail);
                HttpContext.Session.SetString("Password", myUser.UserPassword);
                HttpContext.Session.SetString("Id", myUser.Sno.ToString());
            return Ok(new {Message = "Login Successfull"});
            }
            return Unauthorized(new { Message = "Invalid Credentials" });
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            // Clear the session
            HttpContext.Session.Clear();

            return Ok(new { Message = "Logout successful" });
        }

        [HttpGet("profile")]
        public IActionResult GetProfile()
        {
            var username = HttpContext.Session.GetString("Username");
            var useremail = HttpContext.Session.GetString("Useremail");
            var password = HttpContext.Session.GetString("Password");
            var id = HttpContext.Session.GetString("Id");

            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized(new { Message = "User is not logged in" });
            }

            return Ok(new { Username = username, Useremail = useremail, Password = password, Id = id});
        }
    }
}
