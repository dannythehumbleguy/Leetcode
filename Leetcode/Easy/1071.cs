using NUnit.Framework;

namespace Leetcode.Easy;

public class Solution_1071
{
    [TestCase("ABCABC", "ABC", "ABC")]
    [TestCase("ABABAB", "ABAB", "AB")]
    [TestCase("LEET", "CODE", "")]
    [TestCase("TAUXXTAUXXTAUXXTAUXXTAUXX", "TAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXXTAUXX", "TAUXX")]
    public void TestWithFracture1(string f, string s, string r)
    {
        Assert.AreEqual(r, GcdOfStrings(s, f));
    }

    public string GcdOfStrings(string str1, string str2)
    {
        var (smaller, larger) = (str1.Length > str2.Length ? str2 : str1, str1.Length > str2.Length ? str1 : str2);
        var offset = 0;
        var wordCount = smaller.Length;

        while (!(wordCount == 1 && offset == smaller.Length))
        {
            if (offset + wordCount > smaller.Length || 
                wordCount != 0 && larger.Length % wordCount != 0 ||
                wordCount != 0 && smaller.Length % wordCount != 0)
            {
                offset = 0;
                wordCount--;
                continue;
            }

            var divider = smaller[offset..(offset + wordCount)];
            if(IsDivider(larger, divider) && IsDivider(smaller, divider))
                return divider;

            offset++;
        }

        return "";
    }

    private bool IsDivider(string denominator, string divider)
    {
        var denominatorIndex = 0;
        var dividerIndex = 0;
        while (denominatorIndex < denominator.Length)
        {
            if (denominator[denominatorIndex] != divider[dividerIndex])
                return false;

            denominatorIndex++;
            dividerIndex++;
            if (dividerIndex >= divider.Length)
                dividerIndex = 0;
        }
        return true;
    }
}