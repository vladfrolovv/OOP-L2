#region

using OOP_L2.Utilities;

#endregion

namespace OOP_L2.FilesSystem;

public class FileSystem
{


    public FileSystem(FSDirectory main)
    {
        MainDirectory = main;
    }
    private FSDirectory MainDirectory { get; }


    public FSFile GetFileByPath(string path)
    {
        var pathParts = path.Split('/');
        TreeNode currentDirectory = MainDirectory;
        foreach (var pathPart in pathParts)
        {
            // Console.WriteLine($"Path {pathPart}");

            currentDirectory = currentDirectory.GetChild(pathPart);
        }

        if (currentDirectory is not FSFile || currentDirectory == null)
        {
            throw new ArgumentException("File not found.");
        }

        return currentDirectory is FSFile ? currentDirectory as FSFile : null;
    }


    public TreeNode GetFileOrDirectoryInDirectory(string id, string from)
    {
        var findFrom = FindDirectory(from);
        if (findFrom.GetChild(id) == null)
        {
            throw new ArgumentException("File or directory nor found.");
        }

        return findFrom.GetChild(id);
    }


    public bool IsDirectory(TreeNode treeNode)
    {
        return treeNode is FSDirectory;
    }


    public void AddFile(List<FSFile> files, string? to = null)
    {
        var directoryToAdd = string.IsNullOrEmpty(to) ? MainDirectory : FindDirectory(to);
        foreach (var file in files)
        {
            try
            {
                directoryToAdd.Add(file);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error, directory wont be added: {e.Message}");
            }
        }
    }


    public void AddDirectory(List<FSDirectory> directories, string? to = null)
    {
        var directoryToAdd = string.IsNullOrEmpty(to) ? MainDirectory : FindDirectory(to);
        foreach (var directory in directories)
        {
            try
            {
                directoryToAdd.Add(directory);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error, directory wont be added: {e.Message}");
            }
        }
    }


    public void Remove(string id, string? from = null)
    {
        FSDirectory directoryToRemoveFrom = string.IsNullOrEmpty(from) ? MainDirectory : FindDirectory(from);
        directoryToRemoveFrom.RecursiveDescent(node =>
        {
            if (node.id == id)
            {
                if (node.Parent == null)
                {
                    throw new ArgumentException(paramName: nameof(TreeNode), message: "Cannot remove root directory. ");
                }

                node.Parent.Remove(node.id);
            }
        });
    }


    public void Rename(string file, string renameTo)
    {
    }


    private FSDirectory FindDirectory(string id)
    {
        TreeNode treeNode = null;
        MainDirectory.RecursiveDescent(node =>
        {
            if (node.id == id)
            {
                treeNode = node;
            }
        });

        if (treeNode == null)
        {
            throw new ArgumentException(paramName: nameof(TreeNode), message: "Directory not found. ");
        }

        return treeNode is FSDirectory ? treeNode as FSDirectory : MainDirectory;
    }


    private FSFile FindFile(string id)
    {
        TreeNode treeNode = null;
        MainDirectory.RecursiveDescent(_id =>
        {
            if (_id.id == id)
            {
                treeNode = _id;
            }
        });

        if (treeNode == null)
        {
            throw new ArgumentException(paramName: nameof(TreeNode), message: "Directory not found. ");
        }

        return treeNode is FSFile ? treeNode as FSFile : null;
    }


    public void OutputAll()
    { // output all files and directories from root folder
        MainDirectory.OutputTree("", true);
    }
}

public class FSDirectory : TreeNode
{

    public FSDirectory(string id) : base(id)
    {
        Title = id;
        CreationTime = DateTime.Now;
    }

    public int AttachedFiles
    {
        get
        {
            return _children.Count;
        }
    }

    public DateTime CreationTime { get; }

    public DateTime LastModificationTime { get; set; }

    public string Title { get; }
}

public class FSFile : TreeNode
{
    private ulong _sizeInBytes;


    public FSFile(string id) : base(id)
    {
        CreationTime = DateTime.Now;
        Title = id;
        _sizeInBytes = (ulong)new Random().Next(0, int.MaxValue);
    }

    public DateTime CreationTime { get; }

    public DateTime LastModificationTime { get; set; }

    public string Title { get; }

    public ulong SizeInBytes
    {
        get
        {
            return _sizeInBytes;
        }
        set
        {
            _sizeInBytes = value;
            LastModificationTime = DateTime.Now;
        }
    }
}
