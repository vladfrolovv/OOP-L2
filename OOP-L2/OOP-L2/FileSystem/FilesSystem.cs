#region

using OOP_L2.Utilities;

#endregion

namespace OOP_L2.FileSystem
{
    public class FileSystem
    {
        public Directory MainDirectory { get; private set;  }


        public FileSystem(Directory main)
        {
            MainDirectory = main;
        }

    }


    public class Directory : TreeNode
    {
        public Directory(string id) : base(id)
        {
        }
    }


    public class File : TreeNode
    {
        public File(string id) : base(id)
        {
        }
    }
}
