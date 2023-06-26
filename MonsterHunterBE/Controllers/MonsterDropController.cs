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

        /// <summary>
        /// Endpoint per la ricerca di tutti i drop presenti nel db
        /// </summary>
        /// <returns>
        /// status 200 e la lista dei drop</returns>
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
        /// <summary>
        /// Endpoimt per la richiesta di un drop specifico e 
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Endpoint per l'aggiunta di un drop al database
        /// </summary>
        /// <param name="drop">Il Body del drop in formato Json</param>
        /// <returns>Status 201 se l'aggiunta va a buon fine,
        /// invecer stauts 404 se l'aggiunta non va a buon fine e restituisce il messaggio di errore</returns>
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
        /// <summary>
        /// Endpoint per l'update del drop 
        /// </summary>
        /// <param name="nome">Il nome del drop da modificare</param>
        /// <param name="drop">Il body in formato Json con le modifiche da apportare</param>
        /// <returns>Status 200 se la richiesta va a buonfine</returns>
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
        /// <summary>
        /// Endpoint per l'eliminazione del drop tramite il suo nome
        /// </summary>
        /// <param name="nome">Il nome del drop da eliminare</param>
        /// <returns>Status 204 se l'eliminazione va a buon fine</returns>
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
