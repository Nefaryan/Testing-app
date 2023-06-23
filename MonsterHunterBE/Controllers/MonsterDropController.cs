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
        public ActionResult<List<MonsterDrop>> GetAllDrop()
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
        public ActionResult<MonsterDrop> GetSingle(string nome)
        {
            try
            {
                var drop = service.SingleDrop(nome);
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
                return CreatedAtAction(nameof(GetSingle), new { nome = drop.Name }, drop);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{nome}")]
        public IActionResult UdateDrop(string nome, MonsterDrop drop)
        {
            try
            {
                service.UpdateDrop(nome, drop);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{nome}")]
        public IActionResult DeleteDrop(string nome)
        {
            try
            {
                service.DeleteDrop(nome);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       
    }
}
