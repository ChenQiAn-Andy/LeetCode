using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode._264
{
    public class Solution
    {
        public int NthUglyNumber( int n )
        {
            int[ ] primes = new int[ ] { 2 , 3 , 5 };
            HashSet<long> memo = new HashSet<long>( ) { 1 };
            List<long> result = new List<long>( ) { 1 };
            for ( int i = 1 ; i < n ; ++i )
            {
                long ugly = result.First( );
                result.RemoveAt( 0 );
                foreach ( long v in primes )
                {
                    long test = v * ugly;
                    if ( !memo.Contains( test ) )
                    {
                        memo.Add( test );
                        result.Add( test );
                    }
                }
                result.Sort( );
            }
            return ( int ) result.First( );
        }
    }
}
