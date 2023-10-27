using NUnit.Framework;

namespace Leetcode.Easy;

public class Solution_977
{
    [Test]
    public void TestWithFracture1()
    {
        var input = new[] { -7, -3, 2, 3, 11 };
        var result = SortedSquares(input);
        var expetedResult = new[] { 4, 9, 9, 49, 121 };
        Assert.IsTrue(expetedResult.SequenceEqual(result));
    }

    [Test]
    public void TestWithFracture2()
    {
        var input = new[] { -3, 0, 2 };
        var result = SortedSquares(input);
        var expetedResult = new[] { 0, 4, 9 };
        Assert.IsTrue(expetedResult.SequenceEqual(result));
    }

    [Test]
    public void TestWithAllNegativeNumber1()
    {
        var input = new[] { -4, -3, -2, -1, };
        var result = SortedSquares(input);
        var expetedResult = new[] { 1, 4, 9, 16 };
        Assert.IsTrue(expetedResult.SequenceEqual(result));
    }

    [Test]
    public void TestWithAllNegativeNumber2()
    {
        var input = new[] { -4, -4, -3 };
        var result = SortedSquares(input);
        var expetedResult = new[] { 9, 16, 16 };
        Assert.IsTrue(expetedResult.SequenceEqual(result));
    }

    [Test]
    public void TestWithAllPositiveNumber()
    {
        var input = new[] { 1, 2, 3, 4 };
        var result = SortedSquares(input);
        var expetedResult = new[] { 1, 4, 9, 16 };
        Assert.IsTrue(expetedResult.SequenceEqual(result));
    }

    public int[] SortedSquares(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
            nums[i] *= nums[i];

        int turning = 0; 
        while (turning < nums.Length - 1 && nums[turning] >= nums[turning + 1])
            turning++;

        var result = new int[nums.Length];
        result[0] = nums[turning];
        var resultPoint = 1;
        int left = turning - 1; 
        int right = turning + 1;

        while (left >= 0 || right < nums.Length)
        {
            if(left < 0) // Can't move left
            {
                result[resultPoint] = nums[right];
                right++;
            } 
            else if(right >= nums.Length) // Can't move right
            {
                result[resultPoint] = nums[left];
                left--;
            }
            else // Can move to both sides
            {
                var leftNum = nums[left];
                var rightNum = nums[right];
                if(leftNum < rightNum)
                {
                    result[resultPoint] = leftNum;
                    left--;
                }
                else
                {
                    result[resultPoint] = rightNum;
                    right++;
                }
            }

            resultPoint++;
        }

        return result;
    }
}
