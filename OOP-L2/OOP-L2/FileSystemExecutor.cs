using OOP_L2.FilesSystem;

namespace OOP_L2;

public class Executor
{
    public static void Main()
    {
        var fileSystem = new FileSystem(new FSDirectory("root"));

        fileSystem.AddDirectory(new List<FSDirectory>
        {
            new FSDirectory("dir1"),
            new FSDirectory("dir1"),
            new FSDirectory("dir2")
        });

        fileSystem.AddDirectory(new List<FSDirectory>
        {
            new FSDirectory("dir1.1"),
            new FSDirectory("dir1.2")
        }, "dir1");

        fileSystem.AddFile(new List<FSFile>()
        {
            new FSFile("file1.exe"),
            new FSFile("file2.exe"),
            new FSFile("file3.exe"),
        }, "dir1.1");

        fileSystem.AddDirectory(new List<FSDirectory>
        {
            new FSDirectory("dir1.1.2"),
            new FSDirectory("dir1.1.2")
        }, "dir1.1");


        Console.WriteLine("\n\n FileSystem we created: \n");
        fileSystem.OutputAll();

        FSFile getFileByPathTest = fileSystem.GetFileByPath("dir1/dir1.1/file2.exe");
        FSDirectory getDirectoryByNameInDirectory = fileSystem.GetFileOrDirectoryInDirectory("dir1.1.2", "dir1.1") as FSDirectory;

        Console.WriteLine($"\n\nGet file by path test | Trying to get {@"dir1/dir1.1/file2.exe"}");
        Console.WriteLine($"Received: {getFileByPathTest.id}");

        Console.WriteLine($"\nGet directory by name in directory test | Trying to get {@"dir1.1.2"} from {@"dir1.1"}");
        Console.WriteLine($"Received: {getDirectoryByNameInDirectory.id}\n\n");

        Console.WriteLine($"Trying to remove {@"dir1.1"} from {@"dir1"}");
        fileSystem.Remove("dir1.1", "dir1");

        Console.WriteLine($"File system after removing {@"dir1.1"} from {@"dir1"}\n\n");
        fileSystem.OutputAll();
    }
}
