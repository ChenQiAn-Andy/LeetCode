using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode._102
{
    public class Solution
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> levels = new List<IList<int>>();
            if(root == null)
            {
                return levels;
            }
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int c = 1;
            while(queue.Count > 0)
            {
                IList<int> level=new List<int>();
                int next = 0;
                while (0 < c--)
                {
                    TreeNode node = queue.Dequeue();
                    level.Add(node.val);
                    if (node.left != null)
                    {
                        ++next;
                        queue.Enqueue(node.left);
                    }
                    if(node.right != null)
                    {
                        ++next;
                        queue.Enqueue(node.right);
                    }
                }
                c = next;
                levels.Add(level);
            }
            return levels;
        }
    }
}
