namespace _01._Climb_the_Peaks;
class Program
{
    static void Main(string[] args)
    {
        List<Peak> peaks = new List<Peak>()
        {
            new Peak("Vihren", 80),
            new Peak("Kutelo", 90),
            new Peak("Banski Suhodol", 100),
            new Peak("Polezhan", 60),
            new Peak("Kamenitza", 70),
        };

        List<Peak> conqueredPeaks = new List<Peak>();

        Stack<int> dailyFoods = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
        Queue<int> dailyStaminas = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));

        while (dailyFoods.Count > 0 && peaks.Count > 0)
        {
            int dailyFood = dailyFoods.Pop();
            int dailyStamina = dailyStaminas.Dequeue();

            Peak peak = peaks[0];
            if (dailyFood + dailyStamina >= peak.Difficulty)
            {
                conqueredPeaks.Add(peak);
                peaks.RemoveAt(0);
            }
        }

        if (peaks.Count == 0) // all are concquiered
        {
            Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
        }
        else
        {
            Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
        }

        if (conqueredPeaks.Count > 0)
        {
            Console.WriteLine("Conquered peaks:");
            foreach (Peak peak in conqueredPeaks)
            {
                Console.WriteLine(peak.Name);
            }
        }

    }


    class Peak
    {
        public Peak(string name, int difficulty)
        {
            Name = name;
            Difficulty = difficulty;
        }

        public string Name { get; set; }
        public int Difficulty { get; set; }
    }
}