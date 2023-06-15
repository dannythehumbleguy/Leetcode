using NUnit.Framework;

namespace Leetcode.Medium;

// Easy concept and easy to read
public class Solution_1
{
    [TestCase(new [] {1,2,3,4}, new [] {24,12,8,6})]
    [TestCase(new [] {1,0,0,4}, new [] {0,0,0,0})]
    [TestCase(new [] {-1,1,0,-3,3}, new [] {0,0,9,0,0})]
    public void BaseTestCases(int[] nums, int[] expectedResult)
    {
        var result = ProductExceptSelf(nums);
        Assert.AreEqual(expectedResult, result);
    }
    
    public int[] ProductExceptSelf(int[] nums)
    {
        var result = new int[nums.Length];
        
        var zerosIndexes = nums.Select((u, i) => (Value: u, Index: i))
            .Where(u => u.Value == 0).ToList();
        
        if (zerosIndexes.Count > 1)
            return result;
        
        var mul = nums.Aggregate(1, (u, v) => v == 0 ? u : u * v);
        if (zerosIndexes.Count == 1)
        {
            result[zerosIndexes[0].Index] = mul;
            return result;
        }

        for (var i = 0; i < nums.Length; i++) 
            result[i] = mul / nums[i];

        return result;
    }
}

// Easy concept and hard to read because of optimization
public class Solution238_2 
{
    [TestCase(new [] {1,2,3,4}, new [] {24,12,8,6})]
    [TestCase(new [] {1,0,0,4}, new [] {0,0,0,0})]
    [TestCase(new [] {-1,1,0,-3,3}, new [] {0,0,9,0,0})]
    public void BaseTestCases(int[] nums, int[] expectedResult)
    {
        var result = ProductExceptSelf(nums);
        Assert.AreEqual(expectedResult, result);
    }
    
    public int[] ProductExceptSelf(int[] nums)
    {
        var result = new int[nums.Length];
        
        (int?, int?) zerosIndexes = default;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0 && zerosIndexes.Item1 == null)
                zerosIndexes.Item1 = i;
            else if (nums[i] == 0 && zerosIndexes.Item2 == null)
            {
                zerosIndexes.Item2 = i;
                break;
            }
        }
        
        if (zerosIndexes.Item1 != null && zerosIndexes.Item2 != null)
            return result;

        var mul = 1;
        for (var i = 0; i < nums.Length; i++)
        {
            var value = nums[i];
            if(value == 0)
                continue;
            mul = mul * value;
        }
         
        if (zerosIndexes.Item1 != null)
        {
            result[zerosIndexes.Item1.Value] = mul;
            return result;
        }

        for (var i = 0; i < nums.Length; i++) 
            result[i] = mul / nums[i];

        return result;
    }
}