using Microsoft.AspNetCore.Mvc;
using MonsterHunterBE.Model;
using MonsterHunterBE.Service;

namespace MonsterHunterBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonsterDropController : Controller
    {
        private readonly MonsterDropService dropService;

        public MonsterDropController(MonsterDropService service)
        {
            this.dropService = service;
        }

        [HttpGet]
        public ActionResult<List<MonsterDrop>> GetAllDrop()
        {
            try
            {
                var drop = dropService.GetMonsterDropList();
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
                var drop = dropService.SingleDrop(nome);
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
                dropService.AddMonsterDrop(drop);
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
                dropService.UpdateDrop(nome, drop);
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
                dropService.DeleteDrop(nome);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
