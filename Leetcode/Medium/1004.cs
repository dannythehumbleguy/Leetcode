using NUnit.Framework;

namespace Leetcode.Medium;

public class Solution1004
{
    
    [TestCase(new[] { 0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1 }, 3, 10)]
    [TestCase(new[] { 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0 }, 2 , 6)]
    public void BaseTestCases(int[] sequence, int k, int expectedResult)
    {
        var result = LongestOnes(sequence, k);
        Assert.AreEqual(expectedResult, result);
    }

    public int LongestOnes(int[] nums, int k)
    {
        var longestSeq = 0;
        var currSeq = 0;
        var availableOnes = k;
        var availableOneIndexes = new Queue<int>(k);
        var startIdx = -1;

        for (var i = 0; i < nums.Length; i++)
        {
            var curr = nums[i];

            if (curr == 1)
            {
                currSeq++;
                if (startIdx == -1)
                    startIdx = i;
            }
            else if (availableOnes > 0)
            {
                currSeq++;
                availableOnes--;
                availableOneIndexes.Enqueue(i);
            }
            else
            {
                var newSeq = i - startIdx;
                Console.WriteLine($"{i}:{startIdx}");
                longestSeq = newSeq > currSeq ? newSeq : currSeq;
                currSeq = newSeq;
                availableOnes++;
                startIdx = availableOneIndexes.Dequeue();
            }
        }

        return longestSeq;
    }
}