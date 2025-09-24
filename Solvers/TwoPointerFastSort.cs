namespace Namava.Internship.Core.Solvers;
using System.Collections.Generic;
using Interface;
public class TwoPointerFastSortSolver : ISolver
{
    public string Name => "Two Pointer (Fast Sort)";

    public List<int[]> TwoSum(int[] nums, int target)
    {
        var result = new List<int[]>();
        var indexed = new (int v, int i)[nums.Length];
        for (int i = 0; i < nums.Length; i++)
            indexed[i] = (nums[i], i);
        QuickSort(indexed, 0, indexed.Length - 1);
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
                    else break;
                }

                left++;
            }
            else if (sum < target) left++;
            else right--;
        }

        return result;
    }

    private void QuickSort((int v, int i)[] arr, int left, int right)
    {
        if (left >= right) return;
        int pivot = arr[(left + right) / 2].v;
        int i = left, j = right;
        while (i <= j)
        {
            while (arr[i].v < pivot) i++;
            while (arr[j].v > pivot) j--;
            if (i <= j)
            {
                var temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
                i++;
                j--;
            }
        }

        if (left < j) QuickSort(arr, left, j);
        if (i < right) QuickSort(arr, i, right);
    }
}