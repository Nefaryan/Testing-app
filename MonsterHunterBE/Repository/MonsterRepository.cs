using Microsoft.EntityFrameworkCore;
using MonsterHunterBE.Data;
using MonsterHunterBE.Model;
using MonsterHunterBE.Model.Monster;

namespace MonsterHunterBE.Repository
{
    public class MonsterRepository
    {
        private readonly MonsterHunterContex hunterContex;
        private readonly MonsterWeaknessRepository weaknessRepository;
        private readonly MonsterDropRepository dropRepository;

        public MonsterRepository(MonsterHunterContex hunterContex, MonsterWeaknessRepository weaknessRepository, MonsterDropRepository dropRepository)
        {
            this.hunterContex = hunterContex;
            this.weaknessRepository = weaknessRepository;
            this.dropRepository = dropRepository;
        }
        /// <summary>
        /// Metodo per l'aggiunta di un nuovo mostro nel db
        /// </summary>
        /// <param name="monster">L'oggetto monster da aggiungere</param>
        /// <returns>il mostro aggiunto</returns>
        public Monster AddNewMonster(Monster monster)
        {
            monster.Id = Guid.NewGuid();
            hunterContex.Monsters.Add(monster);
            hunterContex.SaveChanges();
            return monster;
        }
        /// <summary>
        /// Metodo per la ricerca di un mostro tramite il suo id
        /// </summary>
        /// <param name="id">L'id del mostro da cercare</param>
        /// <returns>il mostro</returns>
        /// <exception cref="Exception">
        /// messaggio di errore che viene visuallizato se l'id inserito non viene trovato nel db</exception>

        public Monster GetMonsterById(Guid id)
        {
            var monster = hunterContex.Monsters.FirstOrDefault(m => m.Id == id) ?? throw new Exception("Nessun mostro trovato");
            return monster;
        }

        /// <summary>
        /// Metodo per Recuperare tutti i mostri,drop e weakness a cui sono legati
        /// </summary>
        /// <returns></returns>
        public List<Monster> GetAll()
        {
            return hunterContex.Monsters
                .Include(x => x.Drop)
                .Include(y => y.Weakness).ToList();
        }

        /// <summary>
        /// Metodo di aggiornameto del mostro tramite il suo id, è possibile aggiornare solo
        /// descrizione, note e imageUrl
        /// </summary>
        /// <param name="id">L'id del mostro da aggioranre</param>
        /// <param name="monster">L'oggetto con gli aggiornameti</param>
        /// <returns>Il mostro aggiornato</returns>
        public Monster UpdateMonster(Guid id, Monster monster)
        {
            try
            {
                var eXMonster = hunterContex.Monsters.FirstOrDefault(m => m.Id == id) ?? throw new Exception("Monster not found");
                eXMonster.Description = monster.Description;
                eXMonster.Note = monster.Note;
                eXMonster.ImageUrls = monster.ImageUrls;

                hunterContex.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return monster;
        }

        /// <summary>
        /// Eliminazione del mostro tramite il suo id
        /// </summary>
        /// <param name="id">L'id del mostro da eliminare</param>
        public void DeleteMonster(Guid id)
        {
            var monster = hunterContex.Monsters.FirstOrDefault(m => m.Id == id);
            if (monster != null)
            {
                hunterContex.Monsters.Remove(monster);
                hunterContex.SaveChanges();
            }
        }

        /// <summary>
        /// Metodo per aggiungere un drop al mostro
        /// </summary>
        /// <param name="monsterId">L'id del mostro a cui a aggiungere il dorp</param>
        /// <param name="dropName">Il nome del drop da aggingere</param>
        public void AddDropToMonster(Guid monsterId, string dropName)
        {
            var monster = GetMonsterById(monsterId);
            var drop = dropRepository.GetDropByName(dropName);

            if (monster != null && drop != null)
            {
                monster.Drop ??= new List<MonsterDrop>();

                monster.Drop.Add(drop);
                UpdateMonster(monsterId, monster);
            }
        }
        /// <summary>
        /// Metodo per aggiungere una debolezza al mostro tramite l'id del mostro e l'id della
        /// debolezza specifica da aggiornare
        /// </summary>
        /// <param name="monsterId">L'id del mostro a cui aggiungere la nuova weakness</param>
        /// <param name="weaknessId">l'id della wekness da aggiungere</param>
        public void AddWeaknessToMonster(Guid monsterId, Guid weaknessId)
        {
            var monster = GetMonsterById(monsterId);
            var weakness = weaknessRepository.GetById(weaknessId);

            if (monster != null && weakness != null)
            {
                // Se la lista è nulla viene istanziata
                monster.Weakness ??= new List<MonsterWeakness>();

                monster.Weakness.Add(weakness);
                UpdateMonster(monsterId, monster);
            }
        }

        /// <summary>
        /// Metodo per cercare un mostro specifico tramite 
        /// </summary>
        /// <param name="name">Il nome del mostro da cercare</param>
        /// <returns>Il mostro col nome corrispodente</returns>
        public Monster FindByName(string name)
        {
            Monster monster = hunterContex.Monsters.FirstOrDefault(x => x.Name == name);
            return monster;
        }
    }
}
