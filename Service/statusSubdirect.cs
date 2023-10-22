using Constructors;

namespace Service
{
    public class statusSubdirect
    {
        public static void SearchFilesRecursively(string directory, FileDesc attribute)
        {
            try
            {
                attribute.FileNames.AddRange(Directory.GetFiles(directory, "*.txt"));
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"No access to directory: {directory}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in directory {directory}: {ex.Message}");
            }

            string[] subdirectories;
            try
            {
                subdirectories = Directory.GetDirectories(directory);
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"No access to subdirectories of: {directory}");
                return;
            }

            foreach (var subdirectory in subdirectories)
            {
                SearchFilesRecursively(subdirectory, attribute);
            }
        }
    }
}
