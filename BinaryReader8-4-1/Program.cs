namespace BinaryReader8_4_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\visot\source\repos\SkillFactory\SkillboxModule8\BinaryReader8-4-1\BinaryFile.bin";
            
            //WriteBinFile(filePath);
            ReadBinFile(filePath);


        }

        static void ReadBinFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Error");
                return;
            }

            var stream = File.Open(filePath, FileMode.Open, FileAccess.Read);

            using (BinaryReader reader = new BinaryReader(stream))
            {
                Console.WriteLine(reader.ReadString());
            }
            stream.Close();
        }

        static void WriteBinFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Error");
                return;
            }

            var stream = File.Open(filePath, FileMode.Open, FileAccess.Write);

            using (BinaryWriter bw = new BinaryWriter(stream))
            {
                bw.Write($"Файл был создан {DateTime.Now} на компьютере в Win10");
            }

            stream.Close();
        }

       
    }
}