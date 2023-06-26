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
        
        /// <summary>
        /// Endpoint per la richiesta al server della lista di tutti i mostri presenti nel database
        /// </summary>
        /// <returns>la risposta  con codice 200 del serve con la lista dei mostri se presenti,
        /// in caso non ce ne siano presenti o si verifichi un altro errore viene scritta in console l'errore
        /// e il server restituisce l'errore 404</returns>
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

        /// <summary>
        /// Endopoint per la richiesta al server di un mostro specifico tramite il suo id
        /// </summary>
        /// <param name="id">L'id del mostro da ricercare</param>
        /// <returns>L'endpoint ritorna satus 200 se viene trovato il mostro legato a quell'id, not found se il mostro
        /// è uguale a null e qualsuasi altro errore porta una risposta 404</returns>
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
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Endpoint per aggiunta del mostro nel db
        /// </summary>
        /// <param name="monster">Il Body dell mostro in formato Json</param>
        /// <returns>Staus 201 se la creazione va a buon fine, in caso si verifichino problemi
        /// viene ritornato lo statu 404 con il messagio relativo all'errore che si è verificato</returns>
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
        /// <summary>
        /// Metodo per l'aggiornameto di un singolo mostro nel database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="monster"></param>
        /// <returns></returns>
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
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Endpoint per cancellare un mostro dal database
        /// </summary>
        /// <param name="id">L'id del mostro da eliminare</param>
        /// <returns> Status 204 se l'eliminazione va a buon fine</returns>
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
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Endpoint per l'aggiunta di un drop al mostro
        /// </summary>
        /// <param name="id">l'id del mostro a cui aggiunger eild rop</param>
        /// <param name="name">il nome del drop da aggiungere</param>
        /// <returns> status 200 se l'aggiunta va a buon fine</returns>
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
        /// <summary>
        /// Endpoint per l'aggiunta di una weakness al mostro
        /// </summary>
        /// <param name="MonsterId">Id del mostro a cui aggiungere la weakness</param>
        /// <param name="WeaknessId">Id della wekness da aggiungere</param>
        /// <returns>stauts 200 se l'aggiunta va a buon fine</returns>
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
        /// <summary>
        /// Endponit per la ricerca di tutti i mostri dello stesso tipo
        /// </summary>
        /// <param name="type">il tipo da cercare</param>
        /// <returns>status 200 e la lista dei mostri del tipo deisderato</returns>
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

        /// <summary>
        /// Endopoint per la richiesta al server di un mostro specifico tramite il suo id
        /// </summary>
        /// <param name="id">L'id del mostro da ricercare</param>
        /// <returns>L'endpoint ritorna satus 200 se viene trovato il mostro legato a quell'id, not found se il mostro
        /// è uguale a null e qualsuasi altro errore porta una risposta 404</returns>
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

        /// <summary>
        /// Endpoint per la ricerca di tutti i drop di uno specifico mostro
        /// </summary>
        /// <param name="nome">Il nome del mostro di cui si desidera la lista dei drop</param>
        /// <returns>Status 200 e la lista dei drop del mostro</returns>
        [HttpGet("/drop/{nome}")]
        public ActionResult<MonsterDrop> GetDropByMonsterName(string nome)
        {
            try
            {
                var drops = monsterService.FindAllDropOfMonster(nome);
                return Ok(drops);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

    }
}
