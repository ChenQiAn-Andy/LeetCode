namespace LeetCode._437
{
    public class Solution
    {
        int paths;
        void Check(TreeNode node, int sum)
        {
            if (node == null)
            {
                return;
            }
            if (node.val == sum)
            {
                ++paths;
            }
            sum -= node.val;
            Check(node.left, sum);
            Check(node.right, sum);
        }

        void Traverse(TreeNode node, int sum)
        {
            if (node == null)
            {
                return;
            }
            Check(node, sum);
            Traverse(node.left, sum);
            Traverse(node.right, sum);
        }

        public int PathSum(TreeNode root, int targetSum)
        {
            Traverse(root, targetSum);
            return paths;
        }
    }
}
