using System.Text;

namespace CreaturesOfTheCode
{
    public class Creature
    {
        public Creature(string name, string kind, int health, string abilities)
        {
            Name = name;
            Kind = kind;
            Health = health;
            Abilities = abilities.Split(", ").ToList();
        }

        public string Name { get; set; }

        public string Kind { get; set; }

        public int Health { get; set; }

        public List<string> Abilities { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name} ({Kind}) has {Health} HP".Trim());

            sb.Append("Abilities: ");
            sb.AppendLine(string.Join(", ", Abilities).Trim());

            return sb.ToString().Trim();
        }
        

    }
}
