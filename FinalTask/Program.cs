using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Путь к исходному файлу с данными
            string inputDataPath = args[0];

            if (String.IsNullOrEmpty(inputDataPath))
            {
                Console.WriteLine("Путь не может быть пустым");
                Console.ReadKey();
                Environment.Exit(Environment.ExitCode);
            }

            if (!File.Exists(inputDataPath))
            {
                Console.WriteLine("Не найден файл " + inputDataPath);
                Console.ReadKey();
                Environment.Exit(Environment.ExitCode);
            }

            try
            {
                Console.WriteLine("Получение данных");
                var students = ReadData(inputDataPath);
                var filesPath = CreateDirectory();
                Console.WriteLine("Данные получены\nСоздаем файлы данных");
                CreateDataFiles(students, filesPath);
                Console.WriteLine("Файлы сохранены в директорию "+filesPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка!\n" + ex.Message);
            }
            Console.ReadKey();
        }

        static Student[] ReadData(string filePath)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            Student[] students;

            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                students = (Student[])formatter.Deserialize(stream);
            }

            return students;
        }

        static string CreateDirectory()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            DirectoryInfo dir = new DirectoryInfo(path + @"\Students");
            if (!dir.Exists)
            {
                dir.Create();
            }
            return dir.FullName;
        }

        static void CreateDataFiles(Student[] students, string path)
        {
            foreach (Student student in students.OrderBy(s => s.Group))
            {
                string filePath = $"{path}\\{student.Group}.txt";
                string text = student.Name + ", " + student.DateOfBirth.ToString("dd-MM-yyyy");
                
                WriteToFile(text, filePath);
            }
        }

        static void WriteToFile(string inputText, string filePath)
        {
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(inputText);
            }
        }
    }
}