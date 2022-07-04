using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode._102
{
    internal class SolutionWrapper102 : SolutionWrapper
    {
        public SolutionWrapper102(string testCasesPath, int parametersPerTestCase) : base(testCasesPath, parametersPerTestCase)
        {
        }

        protected override void Exec(string[] testCase, out string log)
        {
            var solution=new Solution();
            var list=solution.LevelOrder(TreeNodeFactory.Create(testCase[0]));
            log = "["+String.Join(",",list.Select(e=>"["+string.Join(",",e)+"]"))+"]";
        }
    }
}
