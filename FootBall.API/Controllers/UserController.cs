using Microsoft.AspNetCore.Mvc;

namespace FootBall.API.Controllers
{
    using FootBall.API.Context;
    using FootBall.API.Entity;
    using FootBall.API.Models;

    using Microsoft.EntityFrameworkCore;

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext db;

        public UserController(UserContext db)
        {
            this.db = db;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            return await this.db.User.ToListAsync();
        }

        [HttpGet("[action]/{Id}")]
        public async Task<ActionResult<CreateUserModel>> GetById(int id)
        {
            User user = await this.db.User.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                return NotFound();

            return new ObjectResult(user);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<User>> Create([FromQuery] User user)
        {
            if (user == null)
                return this.BadRequest();

            db.User.Add(user);

            await this.db.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<CreateUserModel>> Update ([FromQuery] User user)
        {
            if (user == null)
                return this.BadRequest();

            if (!db.User.Any(x => x.Id == user.Id))
                return this.NotFound();

            db.User.Update(user);
            await db.SaveChangesAsync();

            return Ok(user);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<ActionResult<CreateUserModel>> Delete(int id)
        {
            User user = await this.db.User.FirstOrDefaultAsync(x => x.Id == id);
             
            if (id < 0)
                return NotFound();

            db.User.Remove(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }
    }
}
