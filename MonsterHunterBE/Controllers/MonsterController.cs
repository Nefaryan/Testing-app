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
        public ActionResult<List<Monster>> GetAllMonster()
        {
            try
            {
                var monster = monsterService.GetAll();
                return Ok(monster);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();

            }
        }

        [HttpGet("{id}")]
        public ActionResult<Monster> GetMonster(Guid id)
        {
            try
            {
                var monster = monsterService.GetById(id);
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
                monsterService.AddMonster(monster);
                return CreatedAtAction(nameof(GetMonster), new { id = monster.Id }, monster);
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
                monsterService.UpdateMonster(id, monster);
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
                monsterService.RemoveMonster(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error accured");
            }
        }

        [HttpPut("/addDrop/{id}/{name}")]
        public IActionResult AddDrop(Guid id, string name)
        {
            try
            {
                monsterService.AddDrop(id, name);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("/addWeak/{MonsterId}/{WeaknessId}")]
        public IActionResult AddWeak(Guid MonsterId, Guid WeaknessId)
        {
            try
            {
                monsterService.AddWeakness(MonsterId, WeaknessId);
                return Ok();

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);

            }

        }

        [HttpGet("/type/{type}")]
        public ActionResult<List<Monster>> GetByType(string type)
        {
            try
            {
                var monsters = monsterService.FindAllMonsterOfType(type);
                return Ok(monsters);

            }
            catch (Exception e)
            {
                return NotFound(e.Message);
                
            }
        }

        [HttpGet("/route/{id:Guid}")]
        public IActionResult GetFromRoute([FromRoute] Guid id)
        {
            try
            {
                var monster = monsterService.GetById(id);
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

        [HttpGet("/drop/{nome}")]
        public ActionResult<MonsterDrop> GetDropByMonsterName(string nome)
        {
            try
            {
                var drops = monsterService.FindAllDropOfMonster(nome);
                return Ok(drops);
            }catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

    }
}
