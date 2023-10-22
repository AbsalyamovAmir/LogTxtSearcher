namespace Service
{
    public class Searcher
    {
        public static void SearchInFiles(List<string> files, List<string> words)
        {
            
            try
            {
                bool foundMatches = false;
                foreach (var file in files)
                {
                    if (File.Exists(file))
                    {
                        using (StreamReader reader = new StreamReader(file))
                        {
                            string line;
                            int lineNumber = 0;

                            while ((line = reader.ReadLine()) != null)
                            {
                                lineNumber++;

                                foreach (string word in words)
                                {
                                    if (line.Contains(word))
                                    {
                                        foundMatches = true;
                                        Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId}: Найдено в файле: {file}, строка: {lineNumber}, слово: {word}");
                                    }
                                }

                            }
                        }
                    }
                }
                if (!foundMatches)
                {
                    Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} не нашел совпадений.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
