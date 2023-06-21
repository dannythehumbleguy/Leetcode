using NUnit.Framework;

namespace Leetcode.Medium;

public class Solution5_1 
{
    [TestCase("babad", "bab")]
    [TestCase("cbbd", "bb")]
    [TestCase("ccc", "ccc")]
    [TestCase("cccc", "cccc")]
    public void BaseTests(string input, string expected)
    {
        Assert.AreEqual(expected, LongestPalindrome(input));
    }
    
    public string LongestPalindrome(string input)
    {
        if (input.Length == 0)
            return input;
        
        var leftMaxPalindromeIndex = 0;
        var rightMaxPalindromeIndex = 0;

        for (var i = 0; i < input.Length; i++)
        {
            if (i + 1 != input.Length && input[i] == input[i + 1]) // xx
            {
                var (potentialLeft, potentialRight) = Expand(input , i, i + 1);

                if (rightMaxPalindromeIndex - leftMaxPalindromeIndex < potentialRight - potentialLeft)
                {
                    rightMaxPalindromeIndex = potentialRight;
                    leftMaxPalindromeIndex = potentialLeft;
                }
            }
            
            if (i - 1 != -1 && i + 1 != input.Length && input[i - 1] == input[i + 1]) // xyx
            {
                var (potentialLeft, potentialRight) = Expand(input, i - 1, i + 1);

                if (rightMaxPalindromeIndex - leftMaxPalindromeIndex < potentialRight - potentialLeft)
                {
                    rightMaxPalindromeIndex = potentialRight;
                    leftMaxPalindromeIndex = potentialLeft;
                }
            }
        }
        
        return input[leftMaxPalindromeIndex..(rightMaxPalindromeIndex + 1)];
    }

    private (int Left, int Right) Expand(string input, int left, int right)
    {
        while (right < input.Length && left >= 0 && input[left] == input[right])
        {
            left--;
            right++;
        }

        return (left + 1, right - 1);
    }
}