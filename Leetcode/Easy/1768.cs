using NUnit.Framework;

namespace Leetcode.Easy;

public class Solution_1768 
{

    [TestCase("ab", "pqrs", "apbqrs")]
    [TestCase("a", "b", "ab")]
    [TestCase("adc", "bgh", "abdgch")]
    public void TestWithFracture1(string first, string second, string expetedResult)
    {
        var result = MergeAlternately(first, second);
        Assert.AreEqual(expetedResult, result);
    }

    public string MergeAlternately(string first, string second) 
    {
        var result = new char[first.Length + second.Length];

        var firstIndex = 0;
        var secondIndex = 0;

        for (int i = 0; i < result.Length;)
        {
            if(firstIndex < first.Length)
            {
                result[i] = first[firstIndex];
                firstIndex++;
                i++;
            }

            if(secondIndex < second.Length)
            {
                result[i] = second[secondIndex];
                secondIndex++;
                i++;
            }
        }

        return new string(result);
    }
}