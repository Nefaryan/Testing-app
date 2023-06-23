using Microsoft.AspNetCore.Mvc;
using MonsterHunterBE.Model;
using MonsterHunterBE.Model.Monster;
using MonsterHunterBE.Service;

namespace MonsterHunterBE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonsterController : Controller
    {
        private readonly MonsterService monsterService;


        public MonsterController(MonsterService monsterService)
        {
            this.monsterService = monsterService;

        }

        [HttpGet]
        public ActionResult<List<Monster>> getAllMonster()
        {
            try
            {
                var monster = monsterService.getAll();
                return Ok(monster);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();

            }
        }

        [HttpGet("{id}")]
        public ActionResult<Monster> getMonster(Guid id)
        {
            try
            {
                var monster = monsterService.getById(id);
                if (monster == null)
                {
                    return NotFound();
                }
                return Ok(monster);

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult AddMonster(Monster monster)
        {

            try
            {
                monsterService.addMonster(monster);
                return CreatedAtAction(nameof(getMonster), new { id = monster.Id }, monster);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutMonster(Guid id, Monster monster)
        {
            try
            {
                monsterService.updateMonster(id, monster);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error accured");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMonster(Guid id)
        {
            try
            {
                monsterService.removeMonster(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error accured");
            }
        }

        [HttpPut("/addDrop/{id}/{name}")]
        public IActionResult addDrop(Guid id, string name)
        {
            try
            {
                monsterService.addDrop(id, name);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("/addWeak/{MonsterId}/{WeaknessId}")]
        public IActionResult addWeak(Guid MonsterId, Guid WeaknessId)
        {
            try
            {
                monsterService.addWeakness(MonsterId, WeaknessId);
                return Ok();

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);

            }

        }

        [HttpGet("/type/{type}")]
        public ActionResult<List<Monster>> getByType(string type)
        {
            try
            {
                var monsters = monsterService.FindAllMonsterOfType(type);
                return Ok(monsters);

            }
            catch (Exception e)
            {
                return NotFound();
                ;
            }
        }

        [HttpGet("/route/{id:Guid}")]
        public IActionResult getFromRoute([FromRoute] Guid id)
        {
            try
            {
                var monster = monsterService.getById(id);
                if (monster == null)
                {
                    return NotFound();
                }
                return Ok(monster);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
