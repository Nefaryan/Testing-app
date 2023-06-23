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

        public MonsterWeakness NewWeakness(MonsterWeakness weakness)
        {
            weakness.Id = Guid.NewGuid();
            Monstercontext.MonsterWeaknesses.Add(weakness);
            Monstercontext.SaveChanges();
            return weakness;
        }

        public MonsterWeakness GetById(Guid id)
        {
            var weak = Monstercontext.MonsterWeaknesses.FirstOrDefault(w => w.Id == id);
            if (weak == null)
            {
                throw new Exception("Not found");
            }
            return weak;
        }

        public List<MonsterWeakness> GetAllWeakness()
        {
            return Monstercontext.MonsterWeaknesses.ToList();
        }
        public MonsterWeakness UpdateWeak(Guid id, MonsterWeakness weakness)
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

        public void Delete(Guid id)
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
