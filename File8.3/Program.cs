namespace File8._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\visot\source\repos\SkillFactory\SkillboxModule8\File8.3\Program.cs";

            var file = new FileInfo(filePath);

            if(file.Exists)
            {
                using (StreamWriter sw = file.AppendText())
                {
                    sw.WriteLine("//" + DateTime.Now);
                }

                using (StreamReader sr = file.OpenText())
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
}//15.02.2023 21:28:34
