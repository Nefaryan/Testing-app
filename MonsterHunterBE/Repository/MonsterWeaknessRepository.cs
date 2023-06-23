using MonsterHunterBE.Data;
using MonsterHunterBE.Model;

namespace MonsterHunterBE.Repository
{
    public class MonsterWeaknessRepository
    {
        private readonly MonsterHunterContex Monstercontext;

        public MonsterWeaknessRepository(MonsterHunterContex monstercontext)
        {
            this.Monstercontext = monstercontext;
        }

        public MonsterWeakness newWeakness(MonsterWeakness weakness)
        {
            weakness.Id = Guid.NewGuid();
            Monstercontext.MonsterWeaknesses.Add(weakness);
            Monstercontext.SaveChanges();
            return weakness;
        }

        public MonsterWeakness getById(Guid id)
        {
            var weak = Monstercontext.MonsterWeaknesses.FirstOrDefault(w => w.Id == id);
            if (weak == null)
            {
                throw new Exception("Not found");
            }
            return weak;
        }

        public List<MonsterWeakness> getAllWeakness()
        {
            return Monstercontext.MonsterWeaknesses.ToList();
        }
        public MonsterWeakness updateWeak(Guid id, MonsterWeakness weakness)
        {
            try
            {
                var upWeak = Monstercontext.MonsterWeaknesses.FirstOrDefault(w => w.Id == id);
                if (upWeak == null)
                {
                    throw new Exception($"Unable to update drop: {id}");
                }
                upWeak.WeaknessPerc = weakness.WeaknessPerc;
                upWeak.Name = weakness.Name;


                Monstercontext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return weakness;
        }

        public void delete(Guid id)
        {
            var weak = Monstercontext.MonsterWeaknesses.FirstOrDefault(w => w.Id == id);
            if (weak != null)
            {
                Monstercontext.MonsterWeaknesses.Remove(weak);
                Monstercontext.SaveChanges();
            }
        }
    }
}
