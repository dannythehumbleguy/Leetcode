using System.Text;
using NUnit.Framework;

namespace Leetcode.Medium;

// Solution with expand palindrome from center
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

// Solution with Manacher's algorithm
public class Solution5_2
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
        var a = new char[input.Length * 2 + 3];
        
        a[0] = '$';
        a[1] = '#';
        a[^1] = '@';
        
        var c = 0;
        var radius = 0;
        var palindromeMask = new int[a.Length];
        
        var t = 2;
        foreach (var cq in input) {
            a[t++] = cq;
            a[t++] = '#';
        }

        for(var i = 1; i < palindromeMask.Length - 1; i ++)
        {
            if(i < radius)
                palindromeMask[i] = Math.Min(radius - i, palindromeMask[2 * c - i]);

            var left =  a[i + palindromeMask[i] + 1];
            var right = a[i - palindromeMask[i] - 1];
            while(left == right)
            {
                palindromeMask[i] += 1;
                left =  a[i + palindromeMask[i] + 1];
                right = a[i - palindromeMask[i] -1];
            }
            
            if(i + palindromeMask[i]  > radius)
            {
                radius = i + palindromeMask[i];
                c = i;
            }
        }
        
        var max = int.MinValue;
        var index = 0;
        for(var i = 1; i < palindromeMask.Length - 1; i++)
        {
            if (max >= palindromeMask[i]) 
                continue;
            
            max = palindromeMask[i];
            index = i;
        }

        return new string(a.Where((u, i) => i >= index - max && i <= index + max && u != '#').ToArray());
    }
}