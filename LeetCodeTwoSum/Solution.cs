using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Running time O(N)
/// </summary>
namespace LeetCodeTwoSum
{
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            // store the array in a hash table 
            Dictionary<int, int[]> numsDic = new Dictionary<int, int[]>();

            //o(N) operation 
            for (int i = 0; i < nums.Length; i++)
            {
                if (numsDic.ContainsKey(nums[i]))
                {
                    numsDic[nums[i]][1] = i;
                }
                else
                {
                    numsDic.Add(nums[i], new int[] { i, 0 });

                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                var expectedFound = target - nums[i];

                if (numsDic.ContainsKey(expectedFound))
                {
                    if (numsDic[expectedFound][1] != 0)
                    {
                        return new int[] { numsDic[expectedFound][0], numsDic[expectedFound][1] };
                    }
                    else if (numsDic[expectedFound][0] != i)
                    {
                        return new int[] { numsDic[expectedFound][0], i };
                    }
                }
            }

            // in case of not found 
            return new int[] { };


        }
    }
}