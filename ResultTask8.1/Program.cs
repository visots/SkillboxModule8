namespace ResultTask8._1
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
                DeleteFileOrDirectory(dirInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка удаления!\n " +ex.Message);
            }
        }

        static void DeleteFileOrDirectory(DirectoryInfo dir)
        {
            Console.WriteLine("Поиск в директории " + dir.FullName);

            FileInfo[] files = dir.GetFiles();  
            foreach (var file in files)
            {
                if((DateTime.Now - file.LastAccessTime)>TimeSpan.FromMinutes(30))
                {
                    Console.WriteLine("Удаление файла " + file.FullName);
                    file.Delete();
                }
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach(var d in dirs)
            {
                if ((DateTime.Now - d.LastAccessTime) > TimeSpan.FromMinutes(30))
                {
                    DeleteFileOrDirectory(d);
                    Console.WriteLine("Удаление директории " + d.FullName);
                    d.Delete();
                }
            }
        }
    }
}