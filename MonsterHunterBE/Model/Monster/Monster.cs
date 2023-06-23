

namespace MonsterHunterBE.Model.Monster
{
    public class Monster
    {
        public Guid Id { get; set; }
        public string? Type { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrls { set; get; }
        public List<MonsterWeakness>? Weakness { get; set; }
        public List<MonsterDrop>? Drop { get; set; }
        public string? Note { get; set; }

    }
}
