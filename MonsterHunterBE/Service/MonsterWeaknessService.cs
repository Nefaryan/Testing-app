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

        public List<MonsterWeakness> GetAll()
        {
            return _repository.GetAllWeakness();
        }

        public MonsterWeakness GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public MonsterWeakness AddWeakness(MonsterWeakness monsterWeakness)
        {
            return _repository.NewWeakness(monsterWeakness);
        }

        public MonsterWeakness UpdateWeakness(Guid id, MonsterWeakness monsterWeakness)
        {
            return _repository.UpdateWeak(id, monsterWeakness);
        }

        public void DeleteWeakness(Guid id)
        {
            _repository.Delete(id);
        }
    }
}
