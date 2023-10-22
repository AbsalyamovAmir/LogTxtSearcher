
namespace Constructors
{
    public class FileSearch
    {
        /// <summary>
        /// Директория файла
        /// </summary>
        public string Direct { get; set; }
        /// <summary>
        /// Список файлов
        /// </summary>
        public List<FileDesc> FileWords { get; set; }
        public FileSearch(string direct, List<FileDesc> fileWords)
        {
            Direct = direct;
            FileWords = fileWords;
        }
        public FileSearch()
        {
            Direct = "???";
            FileWords = new List<FileDesc>();
        }
    }
}
