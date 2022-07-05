using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode._606
{
    public class Solution
    {
        public string Tree2str( TreeNode root )
        {
            if ( root.left == null && root.right == null )
            {
                return $"{root.val}";
            }
            if ( root.left == null )
            {
                return root.val + $"()({Tree2str( root.right )})";
            }
            if ( root.right == null )
            {
                return root.val + $"({Tree2str( root.left )})";
            }
            return root.val + $"({Tree2str( root.left )})({Tree2str( root.right )})";
        }
    }
}
