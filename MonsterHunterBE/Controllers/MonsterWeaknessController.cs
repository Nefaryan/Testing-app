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
        /// <summary>
        /// Endpoint per ottenere tutte le debolezze presenti nel db
        /// </summary>
        /// <returns>Status 200 e la lista delle weakness presenti</returns>
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
        /// <summary>
        /// Endpoint per ottenere una singola weakness dal db tramite il suo id
        /// </summary>
        /// <param name="id">id della weakness da ottenre</param>
        /// <returns>Status 200 e i dettaggli della weakness se la ricerca tramite id va a buon fine</returns>
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
        /// <summary>
        /// Endpoint per l'aggiunta di una wekness al db 
        /// </summary>
        /// <param name="weak">Body formato Json della weakness da aggiungere</param>
        /// <returns>Status 201 se la creazione va a buon fine</returns>
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
        /// <summary>
        /// Endpoint per l'update di una weakness tramite il suo di
        /// </summary>
        /// <param name="id">l'id della weakness da aggiornare</param>
        /// <param name="weak">IL body della wekness formato Json</param>
        /// <returns>status 200 se la modifica va a buon fine</returns>
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
        /// <summary>
        /// Endpoint per l'eliminazione della weakness
        /// </summary>
        /// <param name="id">L'id della weakness da eliminare</param>
        /// <returns>status 204 se l'eliminazione va buon fine</returns>
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
