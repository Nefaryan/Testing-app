using MonsterHunterBE.Model;
using MonsterHunterBE.Repository;

namespace MonsterHunterBE.Service
{
    public class MonsterDropService
    {
        private readonly MonsterDropRepository _repository;

        public MonsterDropService(MonsterDropRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Salvataggio sul database della entità MonsterDrop
        /// </summary>
        /// <param name="monsterDrop">
        /// body della chiamata </param>
        /// <returns> l'entià creata </returns>
        public MonsterDrop AddMonsterDrop(MonsterDrop monsterDrop)
        {
            return _repository.AddNewDrop(monsterDrop);
        }
        /// <summary>
        /// Recupero di Tutti i Drop nel sistema
        /// </summary>
        /// <returns></returns>
        public List<MonsterDrop> GetMonsterDropList()
        {
            return _repository.GetDropList();
        }
        /// <summary>
        /// Recupero di un singolo drop
        /// </summary>
        /// <param name="name">Il nome del drop da trovare</param>
        /// <returns>Il drop con il nome corrispondente</returns>
        public MonsterDrop SingleDrop(string name)
        {
            return _repository.GetDropByName(name);
        }
        /// <summary>
        /// Update del drop
        /// </summary>
        /// <param name="nome"> del drop da modifica</param>
        /// <param name="monsterDrop">body con le modifiche del drop</param>
        /// <returns> il drop modificato</returns>
        public MonsterDrop UpdateDrop(string nome, MonsterDrop monsterDrop)
        {
            return _repository.UpdateDrop(nome, monsterDrop);
        }
        /// <summary>
        /// Delete del singolo drop
        /// </summary>
        /// <param name="name">nome del drop da modificare</param>
        public void DeleteDrop(string name)
        {
            _repository.DeleteDrop(name);
        }
    }
}
