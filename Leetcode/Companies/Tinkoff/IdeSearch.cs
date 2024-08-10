using NUnit.Framework;

namespace Leetcode.Companies.Tinkoff;

public class IdeSearch
{
    [TestCase("", "crocodile.txt", true)]
    [TestCase("cro", "", false)]
    [TestCase("coco", "crocodile.txt", true)]
    [TestCase("diel", "crocodile.txt", false)]
    [TestCase("ce", "crocodile.txt", true)]
    public void BaseTests(string search, string file, bool result)
    {
        Assert.AreEqual(result, Search(search, file));
    }
    
    public bool Search(string search, string file)
    {
        if (string.IsNullOrEmpty(search))
            return true;
        
        var searchIndex = 0;

        foreach (var symbol in file)
        {
            if (symbol == search[searchIndex])
                searchIndex++;

            if (searchIndex == search.Length)
                return true;
        }

        return false;
    }
}