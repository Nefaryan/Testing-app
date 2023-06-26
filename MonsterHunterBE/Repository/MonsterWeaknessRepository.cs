using MonsterHunterBE.Data;
using MonsterHunterBE.Model;

namespace MonsterHunterBE.Repository
{
    public class MonsterWeaknessRepository
    {
        private readonly MonsterHunterContex Monstercontext;

        public MonsterWeaknessRepository(MonsterHunterContex monstercontext)
        {
            this.Monstercontext = monstercontext;
        }

        /// <summary>
        /// Metodo per la creazione di un ogetto MonsterWeak, 
        /// il metodo assegna un id generato automaticamente all'ogetto e dopo
        /// lo salva nel db
        /// </summary>
        /// <param name="weakness">Body in Json della richiesta</param>
        /// <returns> L'entità aggiunta al db</returns>
        public MonsterWeakness NewWeakness(MonsterWeakness weakness)
        {
            weakness.Id = Guid.NewGuid();
            Monstercontext.MonsterWeaknesses.Add(weakness);
            Monstercontext.SaveChanges();
            return weakness;
        }


        /// <summary>
        /// Metodo per la ricerca dell'oggetto Monsterweakness tramite id,
        /// il metodo cerca nel db se l'id esiste se non esiste ritorna un eccezione se inve esiste
        /// ritorna l'oggetto legto all'id
        /// </summary>
        /// <param name="id">L'ID da controllare </param>
        /// <returns>l'oggetto legato all'id</returns>
        /// <exception cref="Exception">Restituisce un messaggio("Id non found") in caso quell'id non venga trovato
        /// </exception>
        public MonsterWeakness GetById(Guid id)
        {
            var weak = Monstercontext.MonsterWeaknesses.FirstOrDefault(w => w.Id == id) ?? throw new Exception(" Id Not found");
            return weak;
        }
        /// <summary>
        /// Metodo per la ricerca di tutti gli oggetti persenti nel db
        /// </summary>
        /// <returns>
        /// La lista degli ogetti presenti nel db
        /// </returns>
        public List<MonsterWeakness> GetAllWeakness()
        {
            return Monstercontext.MonsterWeaknesses.ToList();
        }
        /// <summary>
        /// Metodo per l'aggiornamento dell'entità Monster weakness, tramite l'identificativo id
        /// </summary>
        /// <param name="id">L'id dell oggetto da aggiornre</param>
        /// <param name="weakness">Il body con le modifiche presenti</param>
        /// <returns></returns>
        public MonsterWeakness UpdateWeak(Guid id, MonsterWeakness weakness)
        {
            try
            {
                var upWeak = Monstercontext.MonsterWeaknesses.FirstOrDefault(w => w.Id == id) ?? throw new Exception($"Unable to update drop: {id}");
                upWeak.WeaknessPerc = weakness.WeaknessPerc;
                upWeak.Name = weakness.Name;
                upWeak.Type = weakness.Type;

                Monstercontext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return weakness;
        }
        /// <summary>
        /// Metodo per l'eliminazione dell'entità tramite id
        /// </summary>
        /// <param name="id">L'id da eliminare</param>
        public void Delete(Guid id)
        {
            var weak = Monstercontext.MonsterWeaknesses.FirstOrDefault(w => w.Id == id);
            if (weak != null)
            {
                Monstercontext.MonsterWeaknesses.Remove(weak);
                Monstercontext.SaveChanges();
            }
        }
    }
}
