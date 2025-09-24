namespace Namava.Internship.Core.Interface;
using System.Collections.Generic;

public interface ISolver
{
    List<int[]> TwoSum(int[] nums, int target);
    string Name { get; }
}gir