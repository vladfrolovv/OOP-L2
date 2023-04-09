namespace OOP_L2.Utilities
{
    public interface IFileSystemIterator
    {
        public void GetNext();
        public bool HasMore();
    }


    public interface IFileSystemIterableCollection
    {
        public IFileSystemIterator CreateDirectoriesIterator(string id);
        public IFileSystemIterator CreateFilesIterator(string id);
    }
}
