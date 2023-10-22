using Constructors;
using Service;

namespace UI
{
    public class MainUI
    {
        public List<FileSearch> directoryList = new List<FileSearch>();
        public static void mainGUI()
        {
            DirectoryManager directoryManager = new DirectoryManager();

            while (true)
            {
                Console.WriteLine("1. Добавить новый элемент");
                Console.WriteLine("2. Показать список директорий");
                Console.WriteLine("3. Изменить элемент списка");
                Console.WriteLine("4. Запустить поиск");
                Console.WriteLine("5. Выйти");
                Console.Write("Выберите действие: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            directoryManager.AddNewElement();
                            break;

                        case 2:
                            Console.Clear();
                            directoryManager.ShowDirectoryList();
                            break;

                        case 3:
                            directoryManager.EditElement();
                            break;

                        case 4:
                            Console.Clear();
                            fileFinder.finder(directoryManager.GetDirectoryList());
                            break;

                        case 5:
                            Console.WriteLine("Выход из программы.");
                            return;

                        default:
                            Console.WriteLine("Неверный выбор, попробуйте еще раз.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Неверный выбор, попробуйте еще раз.");
                }
            }
        }
    }
}
