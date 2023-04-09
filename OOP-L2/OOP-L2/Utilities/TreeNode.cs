#region

using System.Collections;
using OOP_L2.FilesSystem;

#endregion

namespace OOP_L2.Utilities
{
    public class TreeNode
    {
        private readonly Dictionary<string, TreeNode> _children = new Dictionary<string, TreeNode>();

        private TreeNode _searchResult;

        private TreeNode Parent { get; set; }

        public TreeNode SearchResult
        {
            get
            {
                TreeNode searchResult = _searchResult;
                _searchResult = null;

                return searchResult;
            }
            set
            {
                _searchResult = value;
            }
        }

        public readonly string id;


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
            if (_children.ContainsKey(item.id))
            {
                throw new ArgumentException(paramName: nameof(TreeNode), message: "Same file or directory already exists. ");
            }

            item.Parent?._children.Remove(item.id);

            item.Parent = this;
            _children.Add(item.id, item);
        }


        public void Find(string id)
        {
            foreach (string childId in _children.Keys)
            {
                if (childId == id)
                {
                    SetSearchResult(_children[id]);
                    return;
                }

                _children[childId].Find(id);
            }
        }


        private void SetSearchResult(TreeNode result)
        {
            if (Parent != null)
            {
                Parent.SearchResult = result;
                Parent.SetSearchResult(result);
            }
        }


        public void OutputTree(string indent, bool last)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("\\-");
                indent += "  ";
            }
            else
            {
                Console.Write("|-");
                indent += "| ";
            }
            Console.WriteLine(id);

            foreach (string id in _children.Keys)
            {
                _children[id].OutputTree(indent, id == _children.Keys.Last());
            }
        }
    }
}
