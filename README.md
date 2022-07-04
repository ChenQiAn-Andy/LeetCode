## LeetCode本地解题框架 ##
为了充分利用本地编辑器的操作便利性，编写了该框架.

- 使用步骤
	1. 将官网 *默认代码模板* 复制到本地 *Solution.cs* 类，实现所需算法；
	2. 新建继承自 *SolutionWrapper.cs* 的子类，实现Exec方法。SolutionWrapper.cs起代理作用，职责有：
		-  解析测试样例；
		-  创建 *Solution.cs* 实例并传入测试数据；
		-  打印测试结果.
	3. 在 *Program.cs* 中实例化该SolutionWrapper.cs子类，传入 *测试样例* 文件路径，进行测试.
- 举例 [102. 二叉树的层序遍历](https://leetcode.cn/problems/binary-tree-level-order-traversal/ )
	1. *Solution.cs*
	
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
	2. *SolutionWrapper102.cs*

			namespace LeetCode._102
			{
			    internal class SolutionWrapper102 : SolutionWrapper
			    {
			        public SolutionWrapper102(string testCasesPath, int parametersPerTestCase) : base(testCasesPath, parametersPerTestCase)
			        {
			        }
			
			        protected override void Exec(out string log, params string[] testCase)
			        {
			            var solution=new Solution();
			            var list=solution.LevelOrder(TreeNodeFactory.Create(testCase[0]));
			            log = "["+String.Join(",",list.Select(e=>"["+string.Join(",",e)+"]"))+"]";
			        }
			    }
			}
	3. *Program.cs*
	
			using (SolutionWrapper wrapper = new LeetCode._102.SolutionWrapper102("../../../102/Test cases.txt", 1))
			{
			    wrapper.Log();
			}
	4. *Test cases.txt*
	
			[3,9,20,null,null,15,7]
			[1]
			[]
