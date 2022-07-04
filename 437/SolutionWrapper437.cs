namespace LeetCode._437
{
    internal class SolutionWrapper437 : SolutionWrapper
    {
        public SolutionWrapper437(string testCasesPath, int parametersPerTestCase) : base(testCasesPath, parametersPerTestCase)
        {
        }

        protected override void Exec(string[] testCase, out string log)
        {
           var s = new Solution();
           log=s.PathSum(TreeNodeFactory.Create(testCase[0]), int.Parse(testCase[1])).ToString();
        }
    }
}
