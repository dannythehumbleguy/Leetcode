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
        
        var palindromeMiddles = GetPalindromeMiddles(input);
        if (palindromeMiddles.Count == 0)
            return input[0].ToString();

        var leftPalindromeIndex = 0;
        var rightPalindromeIndex = 0;

        foreach (var (leftOrMiddleStart, rightStart) in palindromeMiddles)
        {
            var left = leftOrMiddleStart;
            var right = rightStart ?? leftOrMiddleStart;

            while (right < input.Length && left >= 0 && input[left] == input[right])
            {
                left--;
                right++;
            }
            
            if(rightPalindromeIndex - leftPalindromeIndex >= (right - 1) - (left + 1))
                continue;

            rightPalindromeIndex = right - 1;
            leftPalindromeIndex = left + 1;
        }

        return input[leftPalindromeIndex..(rightPalindromeIndex + 1)];
    }

    private List<(int LeftOrMiddle, int? Right)> GetPalindromeMiddles(string input)
    {
        var res = new List<(int LeftOrMiddle, int? Right)>();
        for (var i = 0; i < input.Length; i++)
        {
            if (i - 1 != -1 && i + 1 != input.Length && input[i - 1] == input[i + 1]) // xyx
                res.Add((i, null));
            if (i + 1 != input.Length && input[i] == input[i + 1]) // xx
                res.Add((i, i + 1));
        }

        return res;
    }
}