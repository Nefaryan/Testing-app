using Microsoft.AspNetCore.Mvc;
using MonsterHunterBE.Model;
using MonsterHunterBE.Service;

namespace MonsterHunterBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonsterDropController : Controller
    {
        private readonly MonsterDropService service;

        public MonsterDropController(MonsterDropService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<List<MonsterDrop>> getAllDrop()
        {
            try
            {
                var drop = service.GetMonsterDropList();
                return Ok(drop);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{nome}")]
        public ActionResult<MonsterDrop> getSingle(string nome)
        {
            try
            {
                var drop = service.singleDrop(nome);
                if (drop == null)
                {
                    return NotFound();
                }
                return Ok(drop);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddDrop([FromBody] MonsterDrop drop)
        {
            try
            {
                service.AddMonsterDrop(drop);
                return CreatedAtAction(nameof(getSingle), new { nome = drop.Name }, drop);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{nome}")]
        public IActionResult updateDrop(string nome, MonsterDrop drop)
        {
            try
            {
                service.updateDrop(nome, drop);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{nome}")]
        public IActionResult deleteDrop(string nome)
        {
            try
            {
                service.deleteDrop(nome);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
