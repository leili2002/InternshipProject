namespace Namava.Internship.Core.Solvers;
using Interface;
using System.Collections.Generic;

public class HashMapSolver : ISolver
{
    public string Name => "Hash Map";

    public List<int[]> TwoSum(int[] nums, int target)
    {
        var result = new List<int[]>();
        var map = new Dictionary<int, List<int>>();
        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];
            if (map.ContainsKey(complement))
            {
                foreach (var idx in map[complement]) result.Add(new[] { idx, i });
            }

            if (!map.ContainsKey(nums[i])) map[nums[i]] = new List<int>();
            map[nums[i]].Add(i);
        }

        return result;
    }
}