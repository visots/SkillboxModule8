using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filesystem8
{
    internal class Drive
    {
        public string DriveName { get; set; }

        public long TotalSpace { get; set; }

        public long FreeSpace { get; set; }

        public Drive (string driveName, long totalSpace, long freeSpace)
        {
            DriveName = driveName;
            TotalSpace = totalSpace;
            FreeSpace = freeSpace;
        }

        Dictionary<string, Folder> Folders = new Dictionary<string, Folder>();

        public void CreateFolder(string name, string storageName)
        {
            Folders.Add(name, new Folder());

            DirectoryInfo dirInfo = new DirectoryInfo(storageName+name);
            if (!dirInfo.Exists)
                 dirInfo.Create();
        }

        public static void GetRootFilesCount(string driveName)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(driveName);
            Console.WriteLine(directoryInfo.GetFiles().Length+ directoryInfo.GetDirectories().Length);
        }
    }
}
