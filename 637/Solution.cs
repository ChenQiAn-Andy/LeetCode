using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode._637
{
    public class Solution
    {
        public IList<double> AverageOfLevels(TreeNode root)
        {
            IList<double> result = new List<double>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int c = 1;
            while(queue.Count > 0)
            {
                int tmp = c,next=0;
                double sum=.0;
                while (0 < tmp--)
                {
                    TreeNode node = queue.Dequeue();
                    sum += node.val;
                    if (node.left != null)
                    {
                        ++next;
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        ++next;
                        queue.Enqueue(node.right);
                    }
                }
                result.Add(sum/c);
                c=next;
            }
            return result;
        }
    }
}
