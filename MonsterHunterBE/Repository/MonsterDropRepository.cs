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

        /// <summary>
        /// Metodo per aggiungere un nuovo drop al db,
        /// il metodo crea un id per il mostro
        /// </summary>
        /// <param name="monsterDrop">Il drop da aggiungere</param>
        /// <returns>Il mostro aggiunto</returns>
        public MonsterDrop AddNewDrop(MonsterDrop monsterDrop)
        {
            monsterDrop.Id = Guid.NewGuid();
            context.MonsterDrops.Add(monsterDrop);
            context.SaveChanges();
            return monsterDrop;
        }
        /// <summary>
        /// Metodo per la ricerca di un drop specifico tramite il suo nome
        /// </summary>
        /// <param name="name">Il nome dell mostro</param>
        /// <returns>Il drop che corrisponde a que nome</returns>
        /// <exception cref="Exception">Se non viene trovato il drop viene generato un messaggio di errore
        /// </exception>
        public MonsterDrop GetDropByName(string name)
        {
            var drop = context.MonsterDrops.FirstOrDefault(d => d.Name == name) ?? throw new Exception("Drop not found");
            return drop;

        }
        /// <summary>
        /// Metodo per ottenre tutti i drop presenti nel db
        /// </summary>
        /// <returns>La lista di tutti i drop presenti</returns>
        public List<MonsterDrop> GetDropList()
        {
            return context.MonsterDrops.ToList();
        }
        /// <summary>
        /// Metodo per aggiornare uno specifico drop
        /// </summary>
        /// <param name="name">Nome del drop da aggiornare</param>
        /// <param name="monsterDrop">modifiche da apportare al drop</param>
        /// <returns>Il drop aggiornato</returns>
        public MonsterDrop UpdateDrop(string name, MonsterDrop monsterDrop)
        {
            try
            {
                var upDrop = context.MonsterDrops.FirstOrDefault(d => d.Name == name) ?? throw new Exception($"Unable to update drop: {name}");
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
        /// <summary>
        /// Metodo per cancellare un drop tramite il suo nome
        /// </summary>
        /// <param name="name">Il nome del drop da eliminare</param>
        public void DeleteDrop(string name)
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
