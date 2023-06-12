using System.Text;
using NUnit.Framework;

namespace Leetcode.Easy;

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

public class Solution844_2 {
    
    [TestCase("c#d#", "ab##", true)]
    [TestCase("ab#c", "ab#c" ,  true)]
    [TestCase("##cc", "cb#c", true)]
    [TestCase("xywrrmp", "xywrrmu#p", true)]
    [TestCase("xywrrmp", "xywrrm#p", false)]
    [TestCase("a#c", "b", false)]
    [TestCase("bxj##tw", "bxo#j##tw", true)]
    [TestCase("bxj##tw", "bxj###tw", false)]
    public void BaseTestCases(string s, string t, bool expectedResult)
    {
        var result = BackspaceCompare(s, t);
        Assert.AreEqual(expectedResult, result);
    }
    
    public bool BackspaceCompare(string s, string t)
    {
        char? sChar = null;
        var sIndex = s.Length - 1;
        var sBackspaces = 0;
        
        char? tChar = null;
        var tIndex = t.Length - 1;
        var tBackspaces = 0;
        
        while (sIndex > 0 || tIndex > 0)
        {
            if (s[sIndex] == '#')
            {
                sBackspaces++;
                DecreaseSIndex();
            }
            else if (sBackspaces > 0)
            {
                sBackspaces--;
                DecreaseSIndex();
            }
            else
            {
                if (sChar == null)
                {
                    sChar = s[sIndex];
                    DecreaseSIndex();
                }
            }
            
                
            if (t[tIndex] == '#')
            {
                tBackspaces++;
                DecreaseTIndex();
            }
            else if (tBackspaces > 0)
            {
                tBackspaces--;
                DecreaseTIndex();
            }
            else
            {
                if (tChar == null)
                {
                    tChar = t[tIndex];
                    DecreaseTIndex();
                }
            }

            if (tChar is not null && sChar is not null && sChar != tChar)
                return false;
              
            if (tChar is not null && sChar is not null)
                tChar = sChar = null;
        }

        void DecreaseSIndex()
        {
            if(sIndex == 0)
                return;
            sIndex--;
        } 
        void DecreaseTIndex()
        {
            if(tIndex == 0)
                return;
            tIndex--;
        }
        return true;
    }
}