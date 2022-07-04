using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode._637
{
    internal class SolutionWrapper637 : SolutionWrapper
    {
        public SolutionWrapper637(string testFilePath, int units) : base(testFilePath, units)
        {
        }

        protected override void Exec(out string log, params string[] testCase)
        {
            var solution =new Solution();
            var list=solution.AverageOfLevels(TreeNodeFactory.Create(testCase[0]));
            log = "["+string.Join(",",list.Select(average=>$"{average:f5}"))+"]";
        }
    }
}
