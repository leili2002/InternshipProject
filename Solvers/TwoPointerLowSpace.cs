namespace Namava.Internship.Core.Solvers;
using System.Collections.Generic;
using Interface;

public class TwoPointerLowSpaceSortSolver : ISolver
{
    public string Name => "Two Pointer (Low-Space Sort)";

    public List<int[]> TwoSum(int[] nums, int target)
    {
        var result = new List<int[]>();
        var indexed = new (int v, int i)[nums.Length];

        for (int i = 0; i < nums.Length; i++)
            indexed[i] = (nums[i], i);

        InsertionSort(indexed);

        int left = 0, right = indexed.Length - 1;
        while (left < right)
        {
            int sum = indexed[left].v + indexed[right].v;

            if (sum == target)
            {
                for (int r = right; r > left; r--)
                {
                    if (indexed[left].v + indexed[r].v == target)
                        result.Add(new[] { indexed[left].i, indexed[r].i });
                    else
                        break;
                }
                left++;
            }
            else if (sum < target)
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return result;
    }

    private void InsertionSort((int v, int i)[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            var key = arr[i];
            int j = i - 1;

            while (j >= 0 && arr[j].v > key.v)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = key;
        }
    }
}