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

        public MonsterDrop AddMonsterDrop(MonsterDrop monsterDrop)
        {
            return _repository.AddNewDrop(monsterDrop);
        }
        public List<MonsterDrop> GetMonsterDropList()
        {
            return _repository.GetDropList();
        }
        public MonsterDrop SingleDrop(string name)
        {
            return _repository.GetDropByName(name);
        }
        public MonsterDrop UpdateDrop(string nome, MonsterDrop monsterDrop)
        {
            return _repository.UpdateDrop(nome, monsterDrop);
        }
        public void DeleteDrop(string name)
        {
            _repository.DeleteDrop(name);
        }
    }
}
