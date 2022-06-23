using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route.Utils
{
    public class Knapsack
    {
        public int DynamicKnapSack(int W, int[] wt, int[] val, int n)
        {
            int[] dp = new int[W + 1];

            for (int i = 1; i < n + 1; i++)
            {
                for (int w = W; w >= 0; w--)
                {

                    if (wt[i - 1] <= w)
                    {
                        var a = dp[w - wt[i - 1]] + val[i - 1];
                        dp[w] = Math.Max(dp[w], dp[w - wt[i - 1]] + val[i - 1]);
                    }
                }
            }
            
            return dp[W];
        }
    }
}
