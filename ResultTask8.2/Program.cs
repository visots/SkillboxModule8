namespace ResultTask8._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введи путь:");
            //string filePath = @"C:\Users\visot\OneDrive\Рабочий стол\Folder";
            string filePath = Console.ReadLine();

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
                Console.WriteLine("Сканирование началось...");
                var size = DirectorySize(dirInfo);
                Console.WriteLine("Сканирование завершено.");
                Console.WriteLine("Размер директории:" + size + " байт");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.ToString());
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