using NUnit.Framework;

namespace Leetcode.Easy;

public class Solution202
{
    [TestCase(2, false)]
    [TestCase(19, true)]
    public void BaseTest(int input, bool expectedResult)
    {
        var result = IsHappy(input);
        Assert.AreEqual(expectedResult, result);
    }
    
    public bool IsHappy(int n)
    {
        var set = new HashSet<int>();
        while (n != 1)
        {
            var copy = n;
            n = 0;

            while (copy != 0)
            {
                var lastNum = copy % 10;
                copy /= 10;
                n += lastNum * lastNum;
            }

            if (!set.Add(n))
                return false;
        }

        return true;
    }
}