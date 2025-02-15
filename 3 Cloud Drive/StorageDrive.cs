using System.Text;

namespace CloudDrive
{
    public class StorageDrive
    {
        public string Name { get; set; }

        public int Capacity { get; set; }

        public List<File> Files;

        public StorageDrive(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Files = new List<File>();
        }

        public void AddFile(File file)
        {
            int sum = 0;

            foreach (File f in Files)
            {
                sum += f.Size;
            }

            if (sum + file.Size <= Capacity)
            {
                Files.Add(file);
            }
        }

        public bool DeleteFile(string name, string extension)
        {
            return Files.Remove(Files.Find(f => f.Name == name && f.Extension == extension));
        }

        public File GetLargestFile()
        {
            return Files.OrderByDescending(f => f.Size).First();
        }

        public File GetFileDetails(string name, string extension)
        {
            return Files.Find(f => f.Name == name && f.Extension == extension);
        }

        public int GetFilesCount()
        {
            return Files.Count;
        }

        public List<File> GetFilesByType(string extension)
        {
            return Files.FindAll(f => f.Extension == extension);
        }

        public string StorageReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Storage Drive:");

            foreach (File file in Files.OrderBy(f => f.Size))
            {
                sb.AppendLine(file.ToString());
            }

            return sb.ToString();
        }

    }
}
