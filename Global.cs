using System.Text;

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
}

public static class TreeNodeFactory
{
    public static TreeNode Create(string data)
    {
        data= data.Trim();
        if (data.Length <= 2)
        {
            return null;
        }
        string[] vals=("#," + data.Substring(1, data.Length - 2)).Split(',');
        if(vals.Length == 1)
        {
            return null;
        }
        Func<int, TreeNode> Traverse = null;
        Traverse = index =>
        {
            if (vals.Length <= index||!int.TryParse(vals[index],out int tmp))
            {
                return null;
            }
            TreeNode root = new TreeNode() { val = tmp };
            root.left = Traverse(index <<= 1);
            root.right = Traverse(index += 1);
            return root;
        };
        return Traverse(1);
    }

    public static string Print(this TreeNode root)
    {
        List<int?> memo = new List<int?>();
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while(queue.Count > 0)
        {
            TreeNode node = queue.Dequeue();
            if (node == null)
            {
                memo.Add(null);
                continue;
            }
            memo.Add(node.val);
            queue.Enqueue(node.left);
            queue.Enqueue(node.right);
        }
        int index=memo.Count;
        while (0 <= index - 1 && memo[--index] == null) ;
        return "["+string.Join(",", memo.Take(index+1).Select(e=>e.HasValue?e.Value.ToString():"null"))+"]";
    }
}

public abstract class SolutionWrapper:IDisposable
{
    StringBuilder logs;

    public SolutionWrapper(string testFilePath,int units)
    {
        if (!File.Exists(testFilePath))
        {
            throw new FileNotFoundException(testFilePath);
        }
        logs = new StringBuilder();
        string[] testCases= File.ReadAllLines(testFilePath);
        for(int i = 0; i < testCases.Length; i+= units)
        {
            Exec(out string log,testCases[i..(i + units)]);
            logs.AppendLine(log);
        }
    }

    protected abstract void Exec(out string log,params string[] testCase);

    public void Log()
    {
        Console.WriteLine(logs.ToString());
    }

    public virtual void Dispose()
    {
        logs.Clear();
        Console.WriteLine("Disposed");
    }
}
