using NUnit.Framework;

namespace Leetcode.Medium;

// Solution with using Queue. 
public class Solution1004_1
{
    [TestCase(new[] { 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1 }, 3, 10)]
    [TestCase(new[] { 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0 }, 2, 6)]
    [TestCase(new[] { 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0 }, 0, 4)]
    [TestCase(new[] { 0, 1, 1, 0, 0, 1, 1, 1 }, 2, 7)]
    public void BaseTestCases(int[] sequence, int k, int expectedResult)
    {
        var result = LongestOnes(sequence, k);
        Assert.AreEqual(expectedResult, result);
    }

    public int LongestOnes(int[] nums, int k)
    {
        var maxSum = 0;
        var indexes = new Queue<int>();
        var currSum = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            var value = nums[i];
            if (value == 1)
                currSum++;
            else if (k > 0)
            {
                indexes.Enqueue(i);
                k--;
                currSum++;
            }
            else
            {
                var dequeueFirstIndex = indexes.TryDequeue(out var firstIndex);
                if (dequeueFirstIndex)
                {
                    var lostOnes = CountLostOnes(nums, firstIndex);
                    currSum -= lostOnes;
                    indexes.Enqueue(i);
                }
                else
                    currSum = 0;
            }

            if (maxSum < currSum)
                maxSum = currSum;
        }

        return maxSum;
    }

    private int CountLostOnes(int[] nums, int firstIndex)
    {
        var res = 0;
        for (var i = firstIndex - 1; i >= 0; i--)
        {
            var value = nums[i];
            if (value == 0)
                return res;
            
            res++;
        }

        return res;
    }
}

// Solution with using two pointers. 
public class Solution1004_2
{
    [TestCase(new[] { 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1 }, 3, 10)]
    [TestCase(new[] { 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0 }, 2, 6)]
    [TestCase(new[] { 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0 }, 0, 4)]
    [TestCase(new[] { 0, 1, 1, 0, 0, 1, 1, 1 }, 2, 7)]
    public void BaseTestCases(int[] sequence, int k, int expectedResult)
    {
        var result = LongestOnes(sequence, k);
        Assert.AreEqual(expectedResult, result);
    }

    public int LongestOnes(int[] nums, int k)
    {
        // first one in calculation
        var begin = 0;
        var maxSum = 0;
        var currSum = 0;

        for (var end = 0; end < nums.Length; end++)
        {
            var value = nums[end];
            if (value == 1)
                currSum++;
            else if(k > 0)
            {
                k--;
                currSum++;
            }
            else
            {
                var newSum = MoveBeginPointer(nums, currSum, ref begin, end);
                currSum = newSum;
            }

            if (maxSum < currSum)
                maxSum = currSum;
        }

        return maxSum;
    }

    private int MoveBeginPointer(int[] nums, int currSum, ref int begin , int end)
    {
        for (var i = begin; i <= end; i++)
        {
            var value = nums[i];
            if (value == 1)
                currSum--;
            else
            {
                begin = i + 1;
                return currSum;
            }
        }

        return currSum;
    }
}