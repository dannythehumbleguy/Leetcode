using NUnit.Framework;

namespace Leetcode.Medium;

// Дерево
public class Solution_334
{
    [Test]
    public void BaseTest1()
    {
        var input = new[] { 1, 2, 3, 4, 5 };
        Assert.AreEqual(true, IncreasingTriplet(input));
    }

    [Test]
    public void BaseTest2()
    {
        var input = new[] { 1, 5, 0, 4, 1, 3 };
        Assert.AreEqual(false, IncreasingTriplet(input));
    }

    [Test]
    public void BaseTest3()
    {
        var input = new[] { 20, 100, 10, 12, 5, 13 };
        Assert.AreEqual(true, IncreasingTriplet(input));
    }

    public bool IncreasingTriplet(int[] nums)
    {
        //var k = 3;
        //var buffer = new int[k + 1];
        //buffer[0] = int.MinValue; 
        //var lastFound = 0;
        //while(lastFound < k)
        //{
        //    var min = int.MinValue;
        //    foreach (var num in nums)
        //    {
        //        if()
        //    }
        //}
        return true;
    }
}
