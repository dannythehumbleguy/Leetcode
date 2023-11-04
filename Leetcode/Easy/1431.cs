using NUnit.Framework;

namespace Leetcode.Easy;

public class Solution_1431
{
    [Test]
    public void BaseTest()
    {
        var candies = new [] { 2, 3, 5, 1, 3 };
        var extraCandies = 3;
        var expectedResult = new [] { true, true, true, false, true };
        Assert.AreEqual(expectedResult, KidsWithCandies(candies, extraCandies));
    }

    public IList<bool> KidsWithCandies(int[] candies, int extraCandies) 
    {
        var max = candies.Max();
        var result = new List<bool>(candies.Length);

        for (int i = 0; i < candies.Length; i++)
        {
            if(candies[i] + extraCandies >= max)
                result.Add(true);
            else 
                result.Add(false);
        }

        return result;
    }
}