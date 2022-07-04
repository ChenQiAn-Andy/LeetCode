using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode._129
{
    public class Solution
    {
        int count;

        void Traverse(TreeNode root,int seed)
        {
            if(root.left == null && root.right == null)
            {
                count += seed+root.val;
                return;
            }
            seed+=root.val;
            if (root.left != null)
            {
                Traverse(root.left, seed*10);
            }
            if(root.right != null)
            {
                Traverse(root.right, seed*10);
            }
        }

        public int SumNumbers(TreeNode root)
        {
            Traverse(root,0); 
            return count;
        }
    }
}
