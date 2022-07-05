using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode._654
{
    internal class SolutionWrapper654 : SolutionWrapper
    {
        public SolutionWrapper654( string testCasesPath , int parametersPerTestCase ) : base( testCasesPath , parametersPerTestCase )
        {
        }

        protected override void Exec( string[ ] testCase , out string log )
        {
            var data = testCase[ 0 ];
            data = data.Trim( );
            var nums = data.Substring( 1 , data.Length - 2 ).Split( ',' ).Select( e => int.Parse( e ) ).ToArray( );
            var solution = new Solution( );
            log = solution.ConstructMaximumBinaryTree( nums ).Print( );
        }
    }
}
