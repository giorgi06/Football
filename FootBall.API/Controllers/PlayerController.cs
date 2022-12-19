using FootBall.API.Context;
using FootBall.API.Entity;
using FootBall.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FootBall.API.Controllers
{
    
    

    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly UserContext db;

        public PlayerController(UserContext db)
        {
            this.db = db;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Player>>> GetAll()
        {
            return await this.db.Player.ToListAsync();
        }

        [HttpGet("[action]/{Id}")]
        public async Task<ActionResult<CreatePlayerModel>> GetById(int id)
        {
            Player player = await this.db.Player.FirstOrDefaultAsync(x => x.Id == id);

            if (player == null)
                return NotFound();

            return new ObjectResult(player);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Player>> Create([FromQuery] Player player)
        {
            if (player == null)
                return this.BadRequest();

            db.Player.Add(player);

            await this.db.SaveChangesAsync();

            return Ok(player);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<CreatePlayerModel>> Update([FromQuery] Player player)
        {
            if (player == null)
                return this.BadRequest();

            if (!db.User.Any(x => x.Id == player.Id))
                return this.NotFound();

            db.Player.Update(player);
            await db.SaveChangesAsync();

            return Ok(player);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<ActionResult<CreatePlayerModel>> Delete(int id)
        {
            Player player = await this.db.Player.FirstOrDefaultAsync(x => x.Id == id);

            if (id < 0)
                return NotFound();

            db.Player.Remove(player);
            await db.SaveChangesAsync();
            return Ok(player);
        }
    }
}

