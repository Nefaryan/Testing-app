using MonsterHunterBE.Model;
using MonsterHunterBE.Repository;

namespace MonsterHunterBE.Service
{
    public class MonsterWeaknessService
    {
        private readonly MonsterWeaknessRepository _repository;

        public MonsterWeaknessService(MonsterWeaknessRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// Metodo per trovare tutte le debolezze presenti nel db
        /// </summary>
        /// <returns></returns>
        public List<MonsterWeakness> GetAll()
        {
            return _repository.GetAllWeakness();
        }
        /// <summary>
        /// Metodo per cercare la singola weakness tramite id
        /// </summary>
        /// <param name="id">L'id della weakness da trovare</param>
        /// <returns>la weakness associata all'id</returns>
        public MonsterWeakness GetById(Guid id)
        {
            return _repository.GetById(id);
        }
        /// <summary>
        /// Metodo per l'aggiunta di una nuova wekness
        /// </summary>
        /// <param name="monsterWeakness">la weakness da aggiungere</param>
        /// <returns>la weakness aggiunta al db</returns>
        public MonsterWeakness AddWeakness(MonsterWeakness monsterWeakness)
        {
            return _repository.NewWeakness(monsterWeakness);
        }
        /// <summary>
        /// Metodo per l'update di una weakeness specifica
        /// </summary>
        /// <param name="id">L'id della weakness da modificare</param>
        /// <param name="monsterWeakness">le modifiche da apportare</param>
        /// <returns>la weakness modificata</returns>
        public MonsterWeakness UpdateWeakness(Guid id, MonsterWeakness monsterWeakness)
        {
            return _repository.UpdateWeak(id, monsterWeakness);
        }
        /// <summary>
        /// Metodo per l'eliminazione di una weakness specifica
        /// </summary>
        /// <param name="id"></param>
        public void DeleteWeakness(Guid id)
        {
            _repository.Delete(id);
        }
    }
}
