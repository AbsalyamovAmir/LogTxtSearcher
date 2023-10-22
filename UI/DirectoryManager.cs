using Constructors;

namespace UI
{
    public class DirectoryManager
    {
        private List<FileSearch> directoryList = new List<FileSearch>();

        public void AddNewElement()
        {
            FileSearch fileSearch = new FileSearch();

            while (true)
            {
                Console.Write("Введите директорию (Direct) или введите 0 для выхода: ");
                string directoryPath = Console.ReadLine();

                if (directoryPath == "0")
                {
                    return; // Выход
                }
                else if (Directory.Exists(directoryPath))
                {
                    fileSearch.Direct = directoryPath;
                    break;
                }
                else
                {
                    Console.WriteLine("Директория не существует. Попробуйте еще раз.");
                }
            }

            List<FileDesc> fileDescList = new List<FileDesc>();
            FileDesc fileDesc = new FileDesc();

            Console.Write("Введите ключевые слова (через пробел) для FileDesc: ");
            string wordsInput = Console.ReadLine();
            string[] words = wordsInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            fileDesc.Words = new List<string>(words);

            fileDescList.Add(fileDesc);
            fileSearch.FileWords = fileDescList;

            directoryList.Add(fileSearch);
            Console.Clear();
        }

        public void ShowDirectoryList()
        {
            if (directoryList.Count == 0)
            {
                Console.WriteLine("Список директорий пуст.");
            }
            else
            {
                string word = "";
                Console.WriteLine("Список директорий:");
                foreach (var fileSearch in directoryList)
                {
                    foreach (var words in fileSearch.FileWords)
                    {
                        word = string.Join(", ", words.Words);
                    }
                    Console.WriteLine($"Директория (Direct): {fileSearch.Direct}, ключевые слова: {word}");
                }
            }
            Console.WriteLine("Введите любой символ для продолжения.");
            Console.ReadLine();
            Console.Clear();
            return;
        }

        public List<FileSearch> GetDirectoryList()
        {
            return directoryList;
        }

        public void EditElement()
        {
            if (directoryList.Count == 0)
            {
                Console.WriteLine("Список директорий пуст. Нечего изменять.");
                return;
            }

            Console.WriteLine("Список директорий:");
            for (int i = 0; i < directoryList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Директория (Direct): {directoryList[i].Direct}");
            }
            Console.Write("Выберите порядковый номер элемента для редактирования: ");
            if (int.TryParse(Console.ReadLine(), out int selectedIndex))
            {
                if (selectedIndex >= 1 && selectedIndex <= directoryList.Count)
                {
                    FileSearch selectedElement = directoryList[selectedIndex - 1];

                    Console.WriteLine($"Текущая директория (Direct): {selectedElement.Direct}");
                    Console.Write("Введите новую директорию (или Enter, чтобы оставить без изменений): ");
                    string newDirectoryPath = Console.ReadLine();

                    if (!string.IsNullOrEmpty(newDirectoryPath) && Directory.Exists(newDirectoryPath))
                    {
                        selectedElement.Direct = newDirectoryPath;
                    }

                    Console.WriteLine("Текущие ключевые слова (FileDesc): " + string.Join(", ", selectedElement.FileWords[0].Words));
                    Console.Write("Введите новые ключевые слова (через пробел) или Enter, чтобы оставить без изменений: ");
                    string newWordsInput = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newWordsInput))
                    {
                        string[] newWords = newWordsInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        selectedElement.FileWords[0].Words = new List<string>(newWords);
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный порядковый номер элемента.");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Порядковый номер должен быть числом.");
            }
        }
    }
}
