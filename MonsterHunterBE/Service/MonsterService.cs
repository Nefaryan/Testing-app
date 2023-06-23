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

        public List<Monster> GetAll()
        {
            return repository.GetAll();
        }

        public Monster GetById(Guid id)
        {
            return repository.GetMonsterById(id);
        }

        public Monster AddMonster(Monster monster)
        {

            return repository.AddNewMonster(monster);
        }

        public Monster UpdateMonster(Guid id, Monster monster)
        {
            return repository.UpdateMonster(id, monster);
        }

        public void RemoveMonster(Guid id)
        {
            repository.DeleteMonster(id);
        }

        public void AddDrop(Guid Id, String name)
        {
            repository.AddDropToMonster(Id, name);
        }

        public void AddWeakness(Guid MonsterId, Guid WeaknessId)
        {
            repository.AddWeaknessToMonster(MonsterId, WeaknessId);
        }

        public IEnumerable<Monster> FindAllMonsterOfType(string type)
        {
            List<Monster> monsters = GetAll();
            return monsters.Where(monster => monster.Type.Equals(type));
        }

        public IEnumerable<MonsterDrop> FindAllDropOfMonster(string name) {
        
            Monster monster = repository.FindByName(name);
            if(monster == null)
            {
                return Enumerable.Empty<MonsterDrop>();
            }
            List<MonsterDrop> monstersDop = monster.Drop.ToList();
            return monstersDop;
        }
    }



}


