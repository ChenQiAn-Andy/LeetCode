namespace LeetCode._437
{
    internal class SolutionWrapper437 : SolutionWrapper
    {
        public SolutionWrapper437(string testCasePath, int parametersPerTestCase) : base(testCasePath, parametersPerTestCase)
        {
        }

        protected override void Exec(out string log,params string[] testCase)
        {
           var s = new Solution();
           log=s.PathSum(TreeNodeFactory.Create(testCase[0]), int.Parse(testCase[1])).ToString();
        }
    }
}
