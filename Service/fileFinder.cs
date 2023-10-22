using Constructors;

namespace Service
{
    public class fileFinder
    {
        public static void finder(List<FileSearch> directoryList)
        {
            foreach (var part in directoryList)
            {
                Console.WriteLine($"Старт поиска в {part.Direct}");
                foreach (var attribute in part.FileWords)
                {
                    statusSubdirect.SearchFilesRecursively(part.Direct, attribute);
                    Console.WriteLine("\n");
                    threadsCalculate.Calculate(attribute, attribute.Words);
                }
            }
            Console.WriteLine("Введите любой символ для продолжения.");
            Console.ReadLine();
            Console.Clear();
            return;
        }
    }
}
