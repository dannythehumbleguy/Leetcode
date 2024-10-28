using NUnit.Framework;

namespace Leetcode.Easy;

public class Solution290
{    
    [TestCase("abba" , "dog cat cat dog", true)]
    [TestCase("abc" , "dog cat dog", false)]
    [TestCase("aaaa", "dog cat cat dog", false)]
    [TestCase("abba", "dog dog dog dog", false)]
    public void BaseTest(string pattern, string s, bool expectedResult)
    {
        var result = WordPattern(pattern, s);
        Assert.AreEqual(expectedResult, result);
    }
    
    public bool WordPattern(string pattern, string s)
    {
        var words = s.Split();
        if (words.Length != pattern.Length)
            return false;
        
        var usedWords = new Dictionary<char, string>();
        var usedWordsReversed = new Dictionary<string, char>();
        
        for (var i = 0; i < words.Length; i++)
        {
            var word = words[i];
            var key = pattern[i];

            var exist1 = usedWords.TryGetValue(key, out var value1);
            if (exist1)
            {
                if (word != value1)
                    return false;
            }
            else usedWords.Add(key, word);
            
            var exist2 = usedWordsReversed.TryGetValue(word, out var value2);
            if (exist2)
            {
                if (key != value2)
                    return false;
            }
            else usedWordsReversed.Add(word, key);
        }

        return true;
    }
}