using NUnit.Framework;

namespace Leetcode.Easy;

public class Solution14_1
{
    [Test]
    public void BaseTest_1()
    {
        var input = new[] {"2"};
        Assert.AreEqual("2", LongestCommonPrefix(input));
    }
    
    [Test]
    public void BaseTest_2()
    {
        var input = new[] {"flower","flow","flight"};
        Assert.AreEqual("fl", LongestCommonPrefix(input));
    }
    
    [Test]
    public void BaseTest_3()
    {
        var input = new[] {""};
        Assert.AreEqual("", LongestCommonPrefix(input));
    }
    
    public string LongestCommonPrefix(string[] strings)
    {
        if (strings.Length == 0)
            return string.Empty;

        var first = strings[0];
        var lastMatchIndex = first.Length;
        
        foreach (var str in strings)
        {
            if (lastMatchIndex > str.Length)
                lastMatchIndex = str.Length;
            
            for (var i = 0; i < lastMatchIndex; i++)
            {
                if (first[i] == str[i])
                    continue;

                lastMatchIndex = i;
                break;
            }
        }

        if (lastMatchIndex == 0)
            return string.Empty;

        return first[..lastMatchIndex];
    }    
}