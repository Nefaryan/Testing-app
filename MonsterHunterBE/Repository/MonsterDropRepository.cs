using MonsterHunterBE.Data;
using MonsterHunterBE.Model;

namespace MonsterHunterBE.Repository
{
    public class MonsterDropRepository
    {
        private readonly MonsterHunterContex context;

        public MonsterDropRepository(MonsterHunterContex context)
        {
            this.context = context;
        }

        public MonsterDrop AddNewDrop(MonsterDrop monsterDrop)
        {
            monsterDrop.Id = Guid.NewGuid();
            context.MonsterDrops.Add(monsterDrop);
            context.SaveChanges();
            return monsterDrop;
        }

        public MonsterDrop GetDropByName(string name)
        {
            var drop = context.MonsterDrops.FirstOrDefault(d => d.Name == name);
            if (drop == null)
            {
                throw new Exception("Drop is null");
            }
            return drop;

        }
        public List<MonsterDrop> GetDropList()
        {
            return context.MonsterDrops.ToList();
        }

        public MonsterDrop updateDrop(string name, MonsterDrop monsterDrop)
        {
            try
            {
                var upDrop = context.MonsterDrops.FirstOrDefault(d => d.Name == name);
                if (upDrop == null)
                {
                    throw new Exception($"Unable to update drop: {name}");
                }
                upDrop.DropRate = monsterDrop.DropRate;
                upDrop.Description = monsterDrop.Description;

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return monsterDrop;

        }

        public void deleteDrop(string name)
        {
            var drop = context.MonsterDrops.FirstOrDefault(d => d.Name == name);
            if (drop != null)
            {
                context.MonsterDrops.Remove(drop);
                context.SaveChanges();
            }
        }


    }
}
