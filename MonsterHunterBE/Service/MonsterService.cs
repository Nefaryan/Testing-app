using MonsterHunterBE.Model;
using MonsterHunterBE.Model.Monster;
using MonsterHunterBE.Repository;

namespace MonsterHunterBE.Service
{
    public class MonsterService
    {
        private readonly MonsterRepository repository;
        private readonly MonsterDropRepository dropRepository;
        private readonly MonsterWeaknessRepository weaknessRepository;
        private readonly MonsterDropService dropService;

        public MonsterService(MonsterRepository repository, MonsterDropRepository dropRepository, MonsterWeaknessRepository weaknessRepository)
        {
            this.repository = repository;
            this.dropRepository = dropRepository;
            this.weaknessRepository = weaknessRepository;
        }

        public List<Monster> getAll()
        {
            return repository.GetAll();
        }

        public Monster getById(Guid id)
        {
            return repository.GetMonsterById(id);
        }

        public Monster addMonster(Monster monster)
        {

            return repository.AddNewMonster(monster);
        }

        public Monster updateMonster(Guid id, Monster monster)
        {
            return repository.updateMonster(id, monster);
        }

        public void removeMonster(Guid id)
        {
            repository.deleteMonster(id);
        }

        public void addDrop(Guid Id, String name)
        {
            repository.AddDropToMonster(Id, name);
        }

        public void addWeakness(Guid MonsterId, Guid WeaknessId)
        {
            repository.AddWeaknessToMonster(MonsterId, WeaknessId);
        }

        public IEnumerable<Monster> FindAllMonsterOfType(string type)
        {

            List<Monster> monsters = getAll();
            return monsters.Where(monster => monster.Type.Equals(type));
        }
    }



}


