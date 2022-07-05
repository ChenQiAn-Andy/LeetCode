using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode._606
{
    internal class SolutionWrapper606 : SolutionWrapper
    {
        public SolutionWrapper606( string testCasesPath , int parametersPerTestCase ) : base( testCasesPath , parametersPerTestCase )
        {
        }

        protected override void Exec( string[ ] testCase , out string log )
        {
            var solution = new Solution( );
            log = solution.Tree2str( TreeNodeFactory.Create( testCase[ 0 ] ) );
        }
    }
}
