#region

using OOP_L2.Utilities;

#endregion

namespace OOP_L2.FilesSystem
{
    public class FileSystem
    {
        public FSDirectory MainDirectory { get; private set; }


        public FileSystem(FSDirectory main)
        {
            MainDirectory = main;
        }


        public void AddDirectory(List<FSDirectory> directories, string? to = null)
        {
            // FSDirectory directoryToAdd = string.IsNullOrEmpty(to) ? MainDirectory : FindDirectory(to);
            FSDirectory directoryToAdd = MainDirectory;
            foreach (FSDirectory directory in directories)
            {
                try
                {
                    MainDirectory.Add(directory);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error, directory wont be added: {e.Message}");
                }
            }
        }


        public TreeNode FindDirectory(string id)
        {
            MainDirectory.Find(id);
            TreeNode treeNode = MainDirectory.SearchResult;

            if (treeNode == null)
            {
                throw new ArgumentException(paramName: nameof(TreeNode), message: "Directory not found. ");
            }

            return treeNode; // todo cast as directory
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
        }
    }


    public class FSFile : TreeNode
    {
        public FSFile(string id) : base(id)
        {
        }
    }
}
