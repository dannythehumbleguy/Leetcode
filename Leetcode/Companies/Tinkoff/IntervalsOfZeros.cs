using NUnit.Framework;

namespace Leetcode.Companies.Tinkoff;

public class IntervalsOfZeros
{
    
    [TestCase("1111111111", 0)]
    [TestCase("000000000", 9)]
    [TestCase("101001001", 2)]
    [TestCase("001001001", 2)]
    [TestCase("101010101", 1)]
    public void BaseTests(string sequence, int result)
    {
        Assert.AreEqual(result, GetMaxInterval(sequence));
    }
    
    public int GetMaxInterval(string sequence)
    {
        var current = 0;
        var max = 0;
        
        foreach (var num in sequence)
        {
            if (num == '0')
            {
                current++;
                continue;
            }

            max = Math.Max(max, current);
            current = 0;
        }

        return Math.Max(max, current);
    }
}