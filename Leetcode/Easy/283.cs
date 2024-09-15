using NUnit.Framework;

namespace Leetcode.Easy;

public class Solution_283_On2
{
    [Test]
    public void BaseTest()
    {
        var data = new[] { 0, 1, 0, 3, 12 };
        MoveZeroes(data);
        Assert.IsTrue(data.SequenceEqual(new[] { 1, 3, 12, 0, 0 }));
    }
    
    [Test]
    public void BaseTest2()
    {
        var data = new[] { 0, 1, 2, 3, 0 };
        MoveZeroes(data);
        Assert.IsTrue(data.SequenceEqual(new[] { 1, 2, 3, 0, 0 }));
    }
    
    [Test]
    public void BaseTest3()
    {
        var data = new[] { 0, 1, 0, 0, 0 };
        MoveZeroes(data);
        Assert.IsTrue(data.SequenceEqual(new[] {  1, 0, 0, 0, 0 }));
    }
    
    [Test]
    public void BaseTest4()
    {
        var data = new[] { 1, 0, 0, 0, 0 };
        MoveZeroes(data);
        Assert.IsTrue(data.SequenceEqual(new[] {  1, 0, 0, 0, 0 }));
    }
    
    public void MoveZeroes(int[] nums)
    {
        var insertedZeroIndex = nums.Length - 1;
        
        for (var i = nums.Length - 1; i >= 0; i--)
        {
            if (nums[i] != 0)
                continue;

            var j = i;

            while (j < insertedZeroIndex)
            {
                (nums[j], nums[j + 1]) = (nums[j + 1], nums[j]);
                j++;
            }
        }
    }
}


public class Solution_283_On
{
    [Test]
    public void BaseTest()
    {
        var data = new[] { 0, 1, 0, 3, 12 };
        MoveZeroes(data);
        Assert.IsTrue(data.SequenceEqual(new[] { 1, 3, 12, 0, 0 }));
    }
    
    [Test]
    public void BaseTest2()
    {
        var data = new[] { 0, 1, 2, 3, 0 };
        MoveZeroes(data);
        Assert.IsTrue(data.SequenceEqual(new[] { 1, 2, 3, 0, 0 }));
    }
    
    [Test]
    public void BaseTest3()
    {
        var data = new[] { 0, 1, 0, 0, 0 };
        MoveZeroes(data);
        Assert.IsTrue(data.SequenceEqual(new[] {  1, 0, 0, 0, 0 }));
    }
    
    [Test]
    public void BaseTest4()
    {
        var data = new[] { 1, 0, 0, 0, 0 };
        MoveZeroes(data);
        Assert.IsTrue(data.SequenceEqual(new[] {  1, 0, 0, 0, 0 }));
    }
    
    public void MoveZeroes(int[] nums)
    {
        var firstZeroIndex = -1;

        for (var i = 0; i < nums.Length; i++)
        {
            if (firstZeroIndex == -1)
            {
                if(nums[i] == 0)
                    firstZeroIndex = i;
                continue;
            }
            
            if(nums[i] == 0)
                continue;
            
            nums[firstZeroIndex] = nums[i];
            nums[i] = 0;
            
            firstZeroIndex++;
        }
    }
}