namespace Filesystem8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            string storageName = "C:\\";

            Drive.GetRootFilesCount("C:\\");

            Drive drive = new Drive("",0,0);
            drive.CreateFolder("folder", storageName);

            Drive.GetRootFilesCount("C:\\");

            
        }
    }
}