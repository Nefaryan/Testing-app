using Microsoft.EntityFrameworkCore;
using MonsterHunterBE.Model;
using MonsterHunterBE.Model.Monster;

namespace MonsterHunterBE.Data
{
    public class MonsterHunterContex : DbContext
    {
        public MonsterHunterContex(DbContextOptions options) : base(options) { }


        public DbSet<Monster> Monsters { get; set; }
        public DbSet<MonsterWeakness> MonsterWeaknesses { get; set; }
        public DbSet<MonsterDrop> MonsterDrops { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurazioni delle entità

            modelBuilder.Entity<MonsterDrop>()
                .Property(d => d.DropRate)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<MonsterWeakness>()
                .Property(w => w.WeaknessPerc)
                .HasColumnType("decimal(18,2)");

            base.OnModelCreating(modelBuilder);
        }
    }
}

