using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode._654
{
    public class Solution
    {
        public TreeNode ConstructMaximumBinaryTree( int[ ] nums )
        {
            if ( nums.Length == 0 )
            {
                return null;
            }
            int index = 0, max = -1;
            for ( int i = 0 ; i < nums.Length ; ++i )
            {
                if ( max < nums[ i ] )
                {
                    index = i;
                    max = nums[ i ];
                }
            }
            TreeNode root = new TreeNode { val = max };
            root.left = ConstructMaximumBinaryTree( nums[ 0..index ] );
            root.right = ConstructMaximumBinaryTree( nums[ ( index + 1 )..nums.Length ] );
            return root;
        }
    }
}
