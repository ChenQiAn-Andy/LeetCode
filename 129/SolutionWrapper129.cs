using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode._129
{
    internal class SolutionWrapper129 : SolutionWrapper
    {
        public SolutionWrapper129(string testCasesPath, int parametersPerTestCase) : base(testCasesPath, parametersPerTestCase)
        {
        }

        protected override void Exec(string[] testCase, out string log)
        {
            var solution = new Solution();
            log = solution.SumNumbers(TreeNodeFactory.Create(testCase[0])).ToString();
        }
    }
}
