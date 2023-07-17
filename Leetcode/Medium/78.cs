using NUnit.Framework;

namespace Leetcode.Medium;

// Generate subsets by binary mask
public class Solution78_1 
{
    [Test]
    public void BaseTest()
    {
        var input = new[] { 1, 2, 3 };
        var output = new[]
        {
            Array.Empty<int>(), 
            new[] { 1 }, 
            new[] { 2 }, 
            new[] { 1, 2 }, 
            new[] { 3 }, 
            new[] { 1, 3 }, 
            new[] { 2, 3 }, 
            new[] { 1, 2, 3 }
        };

        var result = Subsets(input);

        var allSubsetsExists = result.All(u => output.Any(v => v.SequenceEqual(u)));
        Assert.IsTrue(allSubsetsExists);
    }
    
    public IList<IList<int>> Subsets(int[] nums)
    {
        var subsetCount = (int)Math.Pow(2, nums.Length);
        var result = new List<IList<int>>(subsetCount);
        var map = 0;

        for (var i = 0; i < subsetCount; i++)
        {
            var numsByMap = new List<int>();
            var j = 0;
            var mapCopy = map;
            while (mapCopy != 0)
            {
                var remainder = mapCopy % 2;
                mapCopy /= 2;
            
                if(remainder == 1)
                    numsByMap.Add(nums[j]);

                j++;
            }
            
            map++;
            result.Add(numsByMap);
        }

        return result;
    }
}