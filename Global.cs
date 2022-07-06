using System.Text;

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
}

public class CompletelyBinaryTree { }

public class BinarySearchTree { }

public static class TreeNodeFactory
{
    /// <summary>
    /// 反序列化
    /// </summary>
    /// <param name="levelOrderSequence"></param>
    /// <returns>完全二叉树</returns>
    public static TreeNode Create( string levelOrderSequence )
    {
        return Create( levelOrderSequence , new CompletelyBinaryTree());
    }

    /// <summary>
    /// 反序列化
    /// </summary>
    /// <param name="levelOrderSequence"></param>
    /// <param name="_"></param>
    /// <returns>完全二叉树</returns>
    public static TreeNode Create( string levelOrderSequence , CompletelyBinaryTree _)
    {
        levelOrderSequence = levelOrderSequence.Trim( );
        if ( levelOrderSequence.Length <= 2 )
        {
            return null;
        }
        string[ ] vals = ( "#," + levelOrderSequence.Substring( 1 , levelOrderSequence.Length - 2 ) ).Split(",");
        Func<int , TreeNode> Traverse = null;
        Traverse = index =>
        {
            if ( vals.Length <= index || !int.TryParse( vals[ index ] , out int tmp ) )
            {
                return null;
            }
            TreeNode root = new TreeNode( ) { val = tmp };
            root.left = Traverse( index <<= 1 );
            root.right = Traverse( index += 1 );
            return root;
        };
        return Traverse( 1 );
    }

    /// <summary>
    /// 反序列化
    /// </summary>
    /// <param name="levelOrderSequence"></param>
    /// <param name="_"></param>
    /// <returns>二叉搜索树</returns>
    public static TreeNode Create( string levelOrderSequence , BinarySearchTree _ )
    {
        levelOrderSequence = levelOrderSequence.Trim( );
        if ( levelOrderSequence.Length <= 2 )
        {
            return null;
        }
        var lvlOrderSeq = new List<string>( levelOrderSequence.Substring( 1 , levelOrderSequence.Length - 2 ).Split( "," ) )
            .Where( element => element != "null" )
            .Select( element => int.Parse( element ) ).ToList( );
        var inorderSeq = new List<int>( lvlOrderSeq );
        inorderSeq.Sort( );
        var memo = new Dictionary<int , int>( );
        for ( int i = 0 ; i < inorderSeq.Count ; i++ )
        {
            memo.Add( inorderSeq[ i ] , i );
        }
        Func<List<int> , int , int , TreeNode> Traverse = null;
        Traverse = ( lvlOrderSeq , inorderSeqStart , inorderSeqEnd ) =>
        {
            if ( lvlOrderSeq.Count == 0 || inorderSeqStart == inorderSeqEnd )
            {
                return null;
            }
            int value = lvlOrderSeq.First( );
            int i = memo[ value ];
            TreeNode root = new TreeNode { val = value };
            root.left = Traverse( lvlOrderSeq.Where( element => element < value ).ToList( ) , inorderSeqStart , i );
            root.right = Traverse( lvlOrderSeq.Where( element => value < element ).ToList( ) , i + 1 , inorderSeqEnd );
            return root;
        };
        return Traverse( lvlOrderSeq , 0 , inorderSeq.Count );
    }

    /// <summary>
    /// 序列化
    /// </summary>
    /// <param name="root"></param>
    /// <returns>层序遍历序列</returns>
    public static string Print( this TreeNode root )
    {
        List<int?> memo = new List<int?>( );
        Queue<TreeNode> queue = new Queue<TreeNode>( );
        queue.Enqueue( root );
        while ( queue.Count > 0 )
        {
            TreeNode node = queue.Dequeue( );
            if ( node == null )
            {
                memo.Add( null );
                continue;
            }
            memo.Add( node.val );
            queue.Enqueue( node.left );
            queue.Enqueue( node.right );
        }
        int index = memo.Count;
        while ( 0 <= index - 1 && memo[ --index ] == null ) ;
        return "[" + string.Join( "," , memo.Take( index + 1 ).Select( e => e.HasValue ? e.Value.ToString( ) : "null" ) ) + "]";
    }
}

public abstract class SolutionWrapper : IDisposable
{
    StringBuilder logs;

    public SolutionWrapper( string testCasesPath , int parametersPerTestCase )
    {
        if ( !File.Exists( testCasesPath ) )
        {
            throw new FileNotFoundException( testCasesPath );
        }
        logs = new StringBuilder( );
        string[ ] testCases = File.ReadAllLines( testCasesPath );
        for ( int i = 0 ; i < testCases.Length ; i += parametersPerTestCase )
        {
            Exec( testCases[ i..( i + parametersPerTestCase ) ] , out string log );
            logs.AppendLine( log );
        }
    }

    protected abstract void Exec( string[ ] testCase , out string log );

    public void Log( )
    {
        Console.WriteLine( logs.ToString( ) );
    }

    public virtual void Dispose( )
    {
        logs.Clear( );
        Console.WriteLine( "Disposed." );
    }
}
