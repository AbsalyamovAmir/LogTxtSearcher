using Constructors;

namespace Service
{
    public class threadsCalculate
    {
        public static void Calculate(FileDesc attribute, List<string> words) 
        {
            int numThreads = Environment.ProcessorCount;

            List<Thread> threads = new List<Thread>();

            if(attribute.FileNames.Count > numThreads)
            {
                int filesPerThread = attribute.FileNames.Count / numThreads;


                for (int i = 0; i < numThreads; i++)
                {
                    int start = i * filesPerThread;
                    int end = (i == numThreads - 1) ? attribute.FileNames.Count : (i + 1) * filesPerThread;

                    Thread thread = new Thread(() => Searcher.SearchInFiles(attribute.FileNames.GetRange(start, end - start), words));
                    threads.Add(thread);
                    thread.Start();
                }
            }
            else if(attribute.FileNames.Count < numThreads)
            {
                numThreads = Math.Min(Environment.ProcessorCount, attribute.FileNames.Count); // Используем меньшее из двух значений: количество файлов или ядер процессора.

                for (int i = 0; i < numThreads; i++)
                {
                    int fileIndex = i;
                    Thread thread = new Thread(() => Searcher.SearchInFiles(attribute.FileNames, words));
                    threads.Add(thread);
                    thread.Start();
                }
            }
            else if (attribute.FileNames.Count == 0)
            {
                Console.WriteLine("В данном каталоге файлы '*.txt' не найдены");
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }
            Console.WriteLine("\nПоиск завершен.");
        }
    }
}
