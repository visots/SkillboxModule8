namespace ResultTask8._1
{
    internal class Program
    {
        private static int _delitedFilesCount = 0;

        static void Main(string[] args)
        {
            string filePath = args[0];

            if (String.IsNullOrEmpty(filePath))
            {
                Console.WriteLine("Путь не может быть пустым");
                Console.ReadKey();
                Environment.Exit(Environment.ExitCode);
            }

            DirectoryInfo dirInfo = new DirectoryInfo(filePath);

            if (!dirInfo.Exists)
            {
                Console.WriteLine("Не найдена директория" + filePath);
                Console.ReadKey();
                Environment.Exit(Environment.ExitCode);
            }

            try
            {
                long sizeBefore = DirectorySize(dirInfo);
                Console.WriteLine($"Pазмер папки: {sizeBefore} байт");

                DeleteFileOrDirectory(dirInfo);

                long sizeAfter = DirectorySize(dirInfo);

                Console.WriteLine($"Удалено {_delitedFilesCount} файлов");
                
                if (_delitedFilesCount != 0)
                {
                    Console.WriteLine($"Pазмер после удаления: {sizeAfter} байт");
                    Console.WriteLine($"Освобождено: {sizeBefore - sizeAfter} байт");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка удаления!\n " + ex.Message);
            }
        }

        static void DeleteFileOrDirectory(DirectoryInfo dir)
        {
            FileInfo[] files = dir.GetFiles();
            foreach (var file in files)
            {
                if ((DateTime.Now - file.LastAccessTime) > TimeSpan.FromMinutes(30))
                {
                file.Delete();
                _delitedFilesCount++;
                }
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (var d in dirs)
            {
                if ((DateTime.Now - d.LastAccessTime) > TimeSpan.FromMinutes(30))
                {
                  DeleteFileOrDirectory(d);
                  d.Delete();
                }
            }
        }

        static long DirectorySize(DirectoryInfo dir)
        {
            long size = 0;

            FileInfo[] files = dir.GetFiles();

            foreach (var file in files)
                size += file.Length;

            DirectoryInfo[] includedDirs = dir.GetDirectories();

            foreach (var includedDir in includedDirs)
                size += DirectorySize(includedDir);

            return size;
        }
    }
}