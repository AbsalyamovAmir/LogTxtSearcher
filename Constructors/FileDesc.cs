
namespace Constructors
{
    public class FileDesc
    {
        /// <summary>
        /// Название файла
        /// </summary>
        public List<string> FileNames = new List<string>();
        /// <summary>
        /// Список ошибок
        /// </summary>
        public List<string> Words { get; set; }
        public FileDesc(List<string> fileNames, List<string> words)
        {
            FileNames = fileNames;
            Words = words;
        }

        public FileDesc()
        {
            FileNames = new List<string>();
            Words = new List<string>();
        }
    }
}
