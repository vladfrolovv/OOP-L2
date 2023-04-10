#region

#endregion

namespace OOP_L2.Utilities;

public class TreeNode
{
    protected readonly Dictionary<string, TreeNode> _children = new Dictionary<string, TreeNode>();

    public readonly string id;


    protected TreeNode(string id)
    {
        this.id = id;
    }

    public TreeNode Parent { get; set; }


    public TreeNode GetChild(string id)
    {
        return _children.ContainsKey(id) ? _children[id] : null;
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


    public void Remove(string id)
    {
        if (!_children.ContainsKey(id))
        {
            throw new ArgumentException(paramName: nameof(TreeNode), message: "There is no such file or directory.");
        }

        _children.Remove(id);
    }


    public void RecursiveDescent(Action<TreeNode> callback)
    {
        // Console.WriteLine($"Searching for {id} in {this.id}");
        foreach (var childId in _children.Keys)
        {
            // Console.WriteLine($"\t Searching child {childId}");
            callback(_children[childId]);
            if (_children.ContainsKey(childId))
            {
                _children[childId].RecursiveDescent(callback);
            }
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

        foreach (var id in _children.Keys)
        {
            _children[id].OutputTree(indent, id == _children.Keys.Last());
        }
    }
}
