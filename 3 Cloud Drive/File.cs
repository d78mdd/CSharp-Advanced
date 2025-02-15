namespace CloudDrive
{
    public class File
    {
        public string Name { get; set; }

        public string Extension { get; set; }

        public int Size { get; set; }

        public File(string name, string extension, int size)
        {
            Name = name;
            Extension = extension;
            Size = size;
        }

        public override string ToString()
        {
            return $"File: '{Name}.{Extension}' - {Size}KB";
        }
    }
}
