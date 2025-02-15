using System.Text;

namespace CreaturesOfTheCode
{
    public class MythicalCreaturesHub
    {
        public MythicalCreaturesHub(int capacity)
        {
            Capacity = capacity;
            Creatures = new List<Creature>();
        }

        public List<Creature> Creatures { get; set; }

        public int Capacity { get; set; }

        public void AddCreature(Creature creature)
        {
            int count = Creatures
                .FindAll(c => c.Name.ToLower() == creature.Name.ToLower())
                .Count();

            if (count > 0)
            {
                return;
            }

            if (Creatures.Count < Capacity)
            {
                Creatures.Add(creature);
            }
        }

        public bool RemoveCreature(string name)
        {
            int removedCreatures = Creatures.RemoveAll(c => c.Name.ToLower() == name.ToLower());

            if (removedCreatures > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // there will always be exactly one creature with the highest health.
        public Creature GetStrongestCreature()
        {
            Creature creature = Creatures.MaxBy(c => c.Health);

            //Creature creature = Creatures
            //    .OrderByDescending(c => c.Health)
            //    .First();

            return creature;
        }

        public string Details(string creatureName)
        {
            List<Creature> creatures = Creatures
                .FindAll(c => c.Name.ToLower() == creatureName.ToLower());

            if (creatures.Count == 1)
            {
                return creatures.ElementAt(0).ToString().Trim();
            }
            else // count == 0
            {
                return $"Creature with the name {creatureName} not found.".Trim();
            }
        }

        public string GetAllCreatures()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Mythical Creatures:".Trim());

            foreach (Creature creature in Creatures.OrderBy(c => c.Name))
            {
                sb.AppendLine($"{creature.Name} -> {creature.Kind}".Trim());
            }

            return sb.ToString().Trim();
        }
    }
}
