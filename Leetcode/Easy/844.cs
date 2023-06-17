using System.Text;
using NUnit.Framework;

namespace Leetcode.Easy;

// not lazy algorithm
public class Solution844_1 {
    
    [TestCase("c#d#", "ab##", true)]
    [TestCase("ab#c", "ab#c" ,  true)]
    [TestCase("xywrrmp", "xywrrmu#p", true)]
    public void BaseTestCases(string s, string t, bool expectedResult)
    {
        var result = BackspaceCompare(s, t);
        Assert.AreEqual(expectedResult, result);
    }
    
    public bool BackspaceCompare(string s, string t) => GetWithoutBackspace(s) == GetWithoutBackspace(t);
    

    private string GetWithoutBackspace(string input)
    {
        var sb = new StringBuilder();
        var backSpaces = 0;
        for (var i = input.Length - 1; i >= 0; i--)
        {
            if (input[i] == '#')
            {
                backSpaces++;
                continue;
            }

            if (backSpaces > 0)
            {
                backSpaces--;
                continue;
            }

            sb.Append(input[i]);
        }

        return sb.ToString();
    }
}

// lazy algorithm
public class Solution844_2 {
    
    [TestCase("c#d#", "ab##", true)]
    [TestCase("ab#c", "ab#c" ,  true)]
    [TestCase("##cc", "cb#c", true)]
    [TestCase("xywrrmp", "xywrrmu#p", true)]
    [TestCase("xywrrmp", "xywrrm#p", false)]
    [TestCase("a#c", "b", false)]
    [TestCase("bxj##tw", "bxo#j##tw", true)]
    [TestCase("bxj##tw", "bxj###tw", false)]
    [TestCase("a#c###", "ad#c", false)]
    [TestCase("bbbextm", "bbb#extm", false)]
    public void BaseTestCases(string s, string t, bool expectedResult)
    {
        var result = BackspaceCompare(s, t);
        Assert.AreEqual(expectedResult, result);
    }
    
    public bool BackspaceCompare(string s, string t)
    {
        var sLastHandledIndex = s.Length;
        var tLastHandledIndex = t.Length;

        while (tLastHandledIndex > 0 || sLastHandledIndex > 0)
        {
            var sSymbol = GetNextSymbol(s, ref sLastHandledIndex);
            var tSymbol = GetNextSymbol(t, ref tLastHandledIndex);

            if (sSymbol != tSymbol)
                return false;
        }
        
        return true;
    }

    private char? GetNextSymbol(string str, ref int lastHandledIndex)
    {
        if (lastHandledIndex < 0)
            return null;

        var backspaces = 0;
        for (var i = lastHandledIndex - 1; i >= 0; i--)
        {
            lastHandledIndex = i;
            var symbol = str[i];
            if (symbol == '#')
                backspaces++;
            else if (backspaces > 0)
                backspaces--;
            else
                return symbol; 
        }

        return null;
    }
}