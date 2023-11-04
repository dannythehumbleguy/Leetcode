using NUnit.Framework;

namespace Leetcode.Easy;

public class Solution_605
{
    [TestCase(1, true)]
    [TestCase(2, false)]
    public void BaseTests(int flowerCount, bool expectedResult)
    {
        var flowerbed = new [] { 1,0,0,0,1 };
        Assert.AreEqual(expectedResult, CanPlaceFlowers(flowerbed, flowerCount));
    }

    public bool CanPlaceFlowers(int[] flowerbed, int n) 
    {
        for (int i = 0; i < flowerbed.Length; i++)
        {
            if(flowerbed[i] == 1 || 
                (i - 1 >= 0 && flowerbed[i - 1] == 1) || 
                (i + 1 < flowerbed.Length && flowerbed[i + 1] == 1))
                continue;
            
            i++;
            n--;
            if(n <= 0)
                break;
        }

        return n <= 0;
    }
}