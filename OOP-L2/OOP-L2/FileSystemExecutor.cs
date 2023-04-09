using OOP_L2.FilesSystem;

namespace OOP_L2
{
    public class Executor
    {
        public static void Main()
        {
            FileSystem fileSystem = new FileSystem(new FSDirectory("root"));

            // dir1
            FSDirectory dir1 = new FSDirectory("1");

            FSFile dir1File1 = new FSFile("1.1");
            FSFile dir1File2 = new FSFile("1.2");
            FSFile dir1File3 = new FSFile("1.3");

            dir1.Add(dir1File1);
            dir1.Add(dir1File2);
            dir1.Add(dir1File3);

            // dir2
            FSDirectory dir2 = new FSDirectory("2");

            FSDirectory dir2File1 = new FSDirectory("2.1");
            FSDirectory dir2File2 = new FSDirectory("2.2");
            FSDirectory dir2File3 = new FSDirectory("2.3");

            dir2.Add(dir2File1);
            dir2.Add(dir2File2);
            dir2.Add(dir2File3);

            FSDirectory dir3 = new FSDirectory("3");
            FSDirectory dir4 = new FSDirectory("4");

            fileSystem.MainDirectory.Add(dir1);
            fileSystem.MainDirectory.Add(dir2);
            fileSystem.MainDirectory.Add(dir3);
            fileSystem.MainDirectory.Add(dir4);

            fileSystem.FindDirectory("2.3");

            // fileSystem.AddDirectory(new List<FSDirectory>()
            // {
            // new FSDirectory("dir1"),
            // new FSDirectory("dir1"),
            // new FSDirectory("dir2"),
            // });

            fileSystem.OutputAll();
        }
    }
}
