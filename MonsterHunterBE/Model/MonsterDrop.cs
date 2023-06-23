namespace MonsterHunterBE.Model
{
    public class MonsterDrop
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal DropRate { get; set; }
    }
}
