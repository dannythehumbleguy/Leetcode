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

        if (nums.Length < 2)
            return nums;

        int? fracture = null;
        for (int i = 0; i < nums.Length - 1; i++)
            if (nums[i] < nums[i + 1])
            {
                fracture = i;
                break;
            }

        if (fracture is null) // All negative
        {
            Array.Reverse(nums);
            return nums;
        }
        else if(fracture == 0) // All positive
            return nums;

        var result = new int[nums.Length];
        var resultPointer = 0;
        var left = fracture.Value;
        var leftEnded = false;
        var right = fracture.Value + 1;
        var rightEnded = false;

        while (!rightEnded || !leftEnded)
        {
            if(!rightEnded && (leftEnded || nums[right] < nums[left]))
            {
                result[resultPointer] = nums[right];
                resultPointer++;
                right++;
                if (right >= nums.Length)
                    rightEnded = true;
            }
            else if(!leftEnded && (rightEnded || nums[right] >= nums[left]))
            {
                result[resultPointer] = nums[left];
                resultPointer++;
                left--;
                if (left < 0)
                    leftEnded = true;
            }
        }

        return result;
    }
}
