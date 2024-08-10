using NUnit.Framework;

namespace Leetcode.Easy;

public class Solution1 
{
    [Test]
    public void BaseTest_1()
    {
        var source = new[] { 2,7,11,15 };
        
        Assert.AreEqual(new [] {0, 1}, TwoSum(source, 9));
    }
    
    [Test]
    public void BaseTest_2()
    {
        var source = new[] { 3,2,4 };
        
        Assert.AreEqual(new [] {1, 2}, TwoSum(source, 6));
    }

    [Test]
    public void BaseTest_3()
    {
        var source = new[] { 3, 3 };
        
        Assert.AreEqual(new [] {0, 1}, TwoSum(source, 6));
    }

    
    public int[] TwoSum(int[] source, int target)
    {
        var dic = new Dictionary<int, int>();
        
        for (var i = 0; i < source.Length; i++)
        {
            var firstPartOfSum = source[i];
            var secondPartOfSum = target - source[i];
            if (dic.TryGetValue(secondPartOfSum, out var index))
                return new[] { index, i };
            
            dic.TryAdd(firstPartOfSum, i);
        }

        return Array.Empty<int>();
    }
}