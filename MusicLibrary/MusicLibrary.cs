using System.Text;

namespace MusicLibrary
{
    public class MusicLibrary
    {
        public List<Track> Tracks { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }  // maximum number of tracks that can be stored

        public MusicLibrary(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Tracks = new List<Track>();
        }


        public void AddTrack(Track track)
        {
            if (Tracks.Count < Capacity
                && !Tracks.Exists(
                    t =>
                        t.Title.Equals(track.Title, StringComparison.InvariantCultureIgnoreCase) &&
                         t.Artist.Equals(track.Artist, StringComparison.InvariantCultureIgnoreCase)
                         )
                )
            {
                Tracks.Add(track);
            }
        }

        public bool RemoveTrack(string title, string artist)
        {
            return Tracks.Remove(
                Tracks.Find(t =>
                        t.Title.Equals(title, StringComparison.InvariantCultureIgnoreCase) &&
                        t.Artist.Equals(artist, StringComparison.InvariantCultureIgnoreCase)
                         )
                );
        }

        public Track GetLongestTrack()
        {
            return Tracks.OrderBy(t => t.Duration).Last();
            // there will always be exactly one track corresponding that condition
        }

        public string GetTrackDetails(string title, string artist)
        {
            Track? track = Tracks.FirstOrDefault(
                t =>
                    t.Title.Equals(title, StringComparison.InvariantCultureIgnoreCase) &&
                    t.Artist.Equals(artist, StringComparison.InvariantCultureIgnoreCase)
                    );

            if (track == null)
            {
                return "Track not found!";
            }
            else
            {
                return track.ToString();  // trim?
            }
        }

        public int GetTracksCount()
        {
            return Tracks.Count;
        }

        public List<Track> GetTracksByGenre(string genre)
        {
            return Tracks.FindAll(t => t.Genre == genre)
                .OrderBy(t => t.Duration)  // no two tracks will have the same Duration
                .ToList();
        }

        public string LibraryReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Music Library: {Name}");
            sb.AppendLine($"Tracks capacity: {Capacity}");
            sb.AppendLine($"Number of tracks added: {GetTracksCount()}");  // ok?
            sb.AppendLine($"Tracks:");

            foreach (Track track in Tracks
                         .OrderByDescending(t => t.Duration))
            {
                sb.AppendLine($"-{track.ToString()}");
            }

            return sb.ToString().Trim();
        }

    }
}
