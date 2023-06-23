using Microsoft.AspNetCore.Mvc;
using MonsterHunterBE.Model;
using MonsterHunterBE.Service;

namespace MonsterHunterBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonsterWeaknessController : Controller
    {
        private readonly MonsterWeaknessService weakness;

        public MonsterWeaknessController(MonsterWeaknessService monsterWeaknessService)
        {
            this.weakness = monsterWeaknessService;
        }

        [HttpGet]
        public ActionResult<List<MonsterWeakness>> GetAllWeak()
        {
            try
            {
                var weak = weakness.GetAll();
                return Ok(weak);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<MonsterWeakness> GetSingleWeak([FromRoute]Guid id)
        {
            try
            {
                var weak = weakness.GetById(id);
                if (weak == null)
                {
                    return NotFound();
                }
                return Ok(weak);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddWeak([FromBody] MonsterWeakness weak)
        {
            try
            {
                weakness.AddWeakness(weak);
                return CreatedAtAction(nameof(GetSingleWeak), new { id = weak.Id }, weak);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpddateWeakness(Guid id, [FromBody] MonsterWeakness weak)
        {
            try
            {
                weakness.UpdateWeakness(id, weak);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWeakness(Guid id)
        {
            try
            {
                weakness.DeleteWeakness(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
