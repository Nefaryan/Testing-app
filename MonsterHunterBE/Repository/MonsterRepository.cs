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

        public Monster AddNewMonster(Monster monster)
        {
            monster.Id = Guid.NewGuid();
            hunterContex.Monsters.Add(monster);
            hunterContex.SaveChanges();
            return monster;
        }

        public Monster GetMonsterById(Guid id)
        {
            var monster = hunterContex.Monsters.FirstOrDefault(m => m.Id == id);
            if (monster == null)
            {
                throw new Exception("Nessun mostro trovato");
            }
            return monster;
        }

        public List<Monster> GetAll()
        {
            return hunterContex.Monsters
                .Include(x=> x.Drop)
                .Include(y => y.Weakness).ToList();
        }
        
    

        public Monster UpdateMonster(Guid id, Monster monster)
        {
            try
            {
                var eXMonster = hunterContex.Monsters.FirstOrDefault(m => m.Id == id);
                if (eXMonster == null)
                {
                    throw new Exception("Monster not found");
                }
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

        public void DeleteMonster(Guid id)
        {
            var monster = hunterContex.Monsters.FirstOrDefault(m => m.Id == id);
            if (monster != null)
            {
                hunterContex.Monsters.Remove(monster);
                hunterContex.SaveChanges();
            }
        }

        public void AddDropToMonster(Guid monsterId, string dropName)
        {
            var monster = GetMonsterById(monsterId);
            var drop = dropRepository.GetDropByName(dropName);

            if (monster != null && drop != null)
            {
                if (monster.Drop == null)
                    monster.Drop = new List<MonsterDrop>();

                monster.Drop.Add(drop);
                UpdateMonster(monsterId, monster);
            }
        }

        public void AddWeaknessToMonster(Guid monsterId, Guid weaknessId)
        {
            var monster = GetMonsterById(monsterId);
            var weakness = weaknessRepository.getById(weaknessId);

            if (monster != null && weakness != null)
            {
                if (monster.Weakness == null)
                    monster.Weakness = new List<MonsterWeakness>();

                monster.Weakness.Add(weakness);
                UpdateMonster(monsterId, monster);
            }
        }

        public Monster FindByName(string name)
        {
            Monster monster = hunterContex.Monsters.FirstOrDefault(x => x.Name == name);
            return monster;
        }
    }
}
