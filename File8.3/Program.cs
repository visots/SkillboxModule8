namespace File8._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\visot\source\repos\SkillFactory\SkillboxModule8\File8.3\Program.cs";

            if(File.Exists(filePath))
            {
                using (StreamReader sr = File.OpenText(filePath))
                {
                    string data = "";
                    while((data = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(data);
                    }
                }
            }
        }
    }
}