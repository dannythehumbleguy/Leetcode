using NUnit.Framework;

namespace Leetcode.Medium;

public class Solution122_1 
{
    [Test]
    public void TestCase()
    {
        var input = new[] { 7, 1, 5, 3, 6, 4 };
        var res = MaxProfit(input);
        
        Assert.AreEqual(7, res);
    }
    
    public int MaxProfit(int[] prices)
    {
        var buy = int.MinValue;
        var sell = 0;

        foreach (var price in prices)
        {
            var nextBuy = Math.Max(buy, sell - price);
            var nextSell = Math.Max(sell, buy + price);

            buy = nextBuy;
            sell = nextSell;

            Console.WriteLine($"b: {buy}; s: {sell}");
        }

        return sell;
    }
}