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

        public List<MonsterWeakness> getAll()
        {
            return _repository.getAllWeakness();
        }

        public MonsterWeakness getById(Guid id)
        {
            return _repository.getById(id);
        }

        public MonsterWeakness addWeakness(MonsterWeakness monsterWeakness)
        {
            return _repository.newWeakness(monsterWeakness);
        }

        public MonsterWeakness updateWeakness(Guid id, MonsterWeakness monsterWeakness)
        {
            return _repository.updateWeak(id, monsterWeakness);
        }

        public void deleteWeakness(Guid id)
        {
            _repository.delete(id);
        }
    }
}
