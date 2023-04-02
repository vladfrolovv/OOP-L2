#region

using System.Collections;

#endregion

namespace OOP_L2.Utilities
{
    public class TreeNode : IEnumerable<TreeNode>
    {
        private readonly Dictionary<string, TreeNode> _children =
            new Dictionary<string, TreeNode>();

        private readonly string id;

        private TreeNode? Parent { get; set; }


        protected TreeNode(string id)
        {
            this.id = id;
        }


        public TreeNode GetChild(string id)
        {
            return _children[id];
        }


        public void Add(TreeNode item)
        {
            item.Parent?._children.Remove(item.id);

            item.Parent = this;
            _children.Add(item.id, item);
        }


        public IEnumerator<TreeNode> GetEnumerator()
        {
            return _children.Values.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public int Count
        {
            get { return _children.Count; }
        }
    }
}
