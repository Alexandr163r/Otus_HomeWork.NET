using System.Diagnostics;

namespace OtusTask
{
    public class ParallelFileReader
    {
        public void ReadAllFilesInDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine($"папки не ма: {directoryPath}");
                return;
            }

            var sw = Stopwatch.StartNew();
            var files = Directory.GetFiles(directoryPath);

            if (files.Length == 0)
            {
                Console.WriteLine("файлов не ма");
                return;
            }
            
            var tasks = new Task[files.Length];
            var results = new (string FileName, int SpaceCount)[files.Length];

            for (int i = 0; i < files.Length; i++)
            {
                int index = i; 
                tasks[i] = Task.Run(() =>
                {
                    string file = files[index];
                    int threadId = Thread.CurrentThread.ManagedThreadId;
                    Console.WriteLine($"[поток {threadId}] обрабатывает: {Path.GetFileName(file)}");

                    try
                    {
                        string content = File.ReadAllText(file);
                        int spaceCount = content.Count(c => c == ' ');
                        results[index] = (Path.GetFileName(file), spaceCount);
                        Console.WriteLine($"[поток {threadId}] прочитал : {Path.GetFileName(file)}");
                    }
                    catch (Exception ex)
                    {
                        results[index] = (Path.GetFileName(file), -1);
                        Console.WriteLine($"[Поток {threadId}] что то пошло не по плану: {Path.GetFileName(file)} - {ex.Message}");
                    }
                });
            }

            Task.WaitAll(tasks);
            sw.Stop();

            Console.WriteLine($"время: {sw.Elapsed}");
            
            foreach (var result in results)
            {
                Console.WriteLine($"{result.FileName} : {(result.SpaceCount >= 0 ? result.SpaceCount + " пробелов" : "ошибка")}");
            }
        }
    }
}