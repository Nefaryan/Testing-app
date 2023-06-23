using Microsoft.AspNetCore.Mvc;
using MonsterHunterBE.Model;
using MonsterHunterBE.Service;

namespace MonsterHunterBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonsterWeaknessController : Controller
    {
        private readonly MonsterWeaknessService weaknessSerive;

        public MonsterWeaknessController(MonsterWeaknessService monsterWeaknessService)
        {
            this.weaknessSerive = monsterWeaknessService;
        }

        [HttpGet]
        public ActionResult<List<MonsterWeakness>> GetAllWeak()
        {
            try
            {
                var weak = weaknessSerive.GetAll();
                return Ok(weak);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<MonsterWeakness> GetSingleWeak([FromRoute] Guid id)
        {
            try
            {
                var weak = weaknessSerive.GetById(id);
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
                weaknessSerive.AddWeakness(weak);
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
                weaknessSerive.UpdateWeakness(id, weak);
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
                weaknessSerive.DeleteWeakness(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
