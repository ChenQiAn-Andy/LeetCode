using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode._637
{
    internal class SolutionWrapper637 : SolutionWrapper
    {
        public SolutionWrapper637(string testCasesPath, int parametersPerTestCase) : base(testCasesPath, parametersPerTestCase)
        {
        }

        protected override void Exec(string[] testCase, out string log)
        {
            var solution =new Solution();
            var list=solution.AverageOfLevels(TreeNodeFactory.Create(testCase[0]));
            log = "["+string.Join(",",list.Select(average=>$"{average:f5}"))+"]";
        }
    }
}
