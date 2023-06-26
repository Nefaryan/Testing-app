using MonsterHunterBE.Model;
using MonsterHunterBE.Model.Monster;
using MonsterHunterBE.Repository;

namespace MonsterHunterBE.Service
{
    public class MonsterService
    {
        private readonly MonsterRepository repository;

        public MonsterService(MonsterRepository repository)
        {
            this.repository = repository;

        }

        /// <summary>
        /// Metodo per recuperare la lsita dei msotri presenti nel db
        /// </summary>
        /// <returns></returns>
        public List<Monster> GetAll()
        {
            return repository.GetAll();
        }

        /// <summary>
        /// Metodo per recuperare un mostro tramite il suo id
        /// </summary>
        /// <param name="id">l'id del mostro da recuperare</param>
        /// <returns>il mostro corrispondente</returns>
        public Monster GetById(Guid id)
        {
            return repository.GetMonsterById(id);
        }
        /// <summary>
        /// Metodo per l'aggiunta di una nuova entità mostro nel db
        /// </summary>
        /// <param name="monster">il mostro da aggiundre</param>
        /// <returns>il mostro aggiunto</returns>
        public Monster AddMonster(Monster monster)
        {

            return repository.AddNewMonster(monster);
        }
        /// <summary>
        /// Metodo per l'aggioranameto del mostro tramite il suo id
        /// </summary>
        /// <param name="id">L'id da aggiornare</param>
        /// <param name="monster">le modifiche da apportare</param>
        /// <returns> Il mostro mosdificato</returns>
        public Monster UpdateMonster(Guid id, Monster monster)
        {
            return repository.UpdateMonster(id, monster);
        }
        /// <summary>
        /// Metodo per eliminare un mostro dal db
        /// </summary>
        /// <param name="id">l'id del mostro da eliminare</param>
        public void RemoveMonster(Guid id)
        {
            repository.DeleteMonster(id);
        }
        /// <summary>
        /// Metdo di aggiunta di un drop specifico al mostro
        /// </summary>
        /// <param name="Id">L'id del mostro a cui aggiungere il droo</param>
        /// <param name="name">il nome del drop da aggiungere</param>
        public void AddDrop(Guid MonsterId, String DropName)
        {
            repository.AddDropToMonster(MonsterId, DropName);
        }
        /// <summary>
        /// Metodo per l'aggiunta della weakness al mostro
        /// </summary>
        /// <param name="MonsterId">IdL'id del mostro</param>
        /// <param name="WeaknessId">L'id della debolezza</param>
        public void AddWeakness(Guid MonsterId, Guid WeaknessId)
        {
            repository.AddWeaknessToMonster(MonsterId, WeaknessId);
        }

        /// <summary>
        /// Metodo per la ricerca di tutti i mostri di uno stesso tipo
        /// </summary>
        /// <param name="type">il tipo da cercare</param>
        /// <returns>Tutti i mostri che corrispondono a quel tipo</returns>
        public IEnumerable<Monster> FindAllMonsterOfType(string type)
        {
            List<Monster> monsters = GetAll();
            return monsters.Where(monster => monster.Type.Equals(type));
        }
        /// <summary>
        /// Metodo per trovare tutti i drop di un mostro tramite il suo nome
        /// </summary>
        /// <param name="name">il nome del mostro da cui cercare id rop</param>
        /// <returns>La lista dei drop del mostro</returns>
        public IEnumerable<MonsterDrop> FindAllDropOfMonster(string name)
        {

            Monster monster = repository.FindByName(name);
            if (monster == null)
            {
                //Se il mostro è nulla viene restituita una lista vuota
                return Enumerable.Empty<MonsterDrop>();
            }
            List<MonsterDrop> monstersDop = monster.Drop.ToList();
            return monstersDop;
        }
    }



}


