namespace CloudDrive
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //Initialize the repository (StorageDrive)
            StorageDrive storageDrive = new("MyDrive", 5000);

            // Initialize entities (Files)
            File file1 = new("ProjectReport", "pdf", 1200);
            File file2 = new("PhotoAlbum", "zip", 2000);
            File file3 = new("Notes", "txt", 700);
            File file4 = new("Presentation", "pptx", 1500);
            File file5 = new("Draft", "txt", 300);
            File file6 = new("ProjectReport", "pdf", 1200); // Duplicate file with same name and extension

            storageDrive.AddFile(file1);
            storageDrive.AddFile(file2);
            storageDrive.AddFile(file3);
            Console.WriteLine(storageDrive.GetFilesCount());
            // Output: 3

            // Attempt to add a file exceeding capacity
            storageDrive.AddFile(file4); // Skipped because adding this file exceeds capacity
            Console.WriteLine(storageDrive.GetFilesCount());
            // Output: 3

            // Attempt to add a duplicate file
            storageDrive.AddFile(file6); // Skipped because a file with the same name and extension already exists
            Console.WriteLine(storageDrive.GetFilesCount());
            // Output: 3

            // Remove an existing file
            Console.WriteLine(storageDrive.DeleteFile("ProjectReport", "pdf"));
            // Output: True

            // Attempt to remove a non-existent file
            Console.WriteLine(storageDrive.DeleteFile("NonExistent", "docx"));
            // Output: False

            Console.WriteLine(storageDrive.GetFilesCount());
            // Output: 2

            // Get details of an existing file
            Console.WriteLine(storageDrive.GetFileDetails("PhotoAlbum", "zip"));
            // Output: File: 'PhotoAlbum.zip' - 2000KB

            // Attempt to get details of a non-existent file
            Console.WriteLine(storageDrive.GetFileDetails("Presentation", "pptx"));
            // Output: File not found!

            // Add more files
            storageDrive.AddFile(file5);

            // Retrieve files by extension
            List<File> txtFiles = storageDrive.GetFilesByType("txt");
            foreach (var file in txtFiles)
            {
                Console.WriteLine(file);
            }
            // Output:
            // File: 'Draft.txt' - 300KB
            // File: 'Notes.txt' - 700KB

            File largestFile = storageDrive.GetLargestFile();
            Console.WriteLine(largestFile);
            // Output: File: 'PhotoAlbum.zip' - 2000KB

            Console.WriteLine(storageDrive.StorageReport());
            // Output:
            // Storage Drive: MyDrive
            // File: 'Draft.txt' - 300KB
            // File: 'Notes.txt' - 700KB
            // File: 'PhotoAlbum.zip' - 2000KB
        }
    }
}
