// See https://aka.ms/new-console-template for more information
namespace Namava.Internship.Core.Solvers;
using System.Collections.Generic;
using  Namava.Internship.Core.Interface;


public class BruteForceSolver : ISolver
{
    public string Name => "Brute Force";

    public List<int[]> TwoSum(int[] nums, int target)
    {
        var result = new List<int[]>();
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                    result.Add(new[] { i, j });
            }
        }

        return result;
    }
}