using System.Reflection.Metadata;
using System.Text;
using NUnit.Framework;

namespace Leetcode.Medium;

public class Solution_151
{
    [TestCase(" the sky is blue", "blue is sky the")]
    [TestCase("a good   example  ", "example good a")]
    public void BaseTests(string input, string expected)
    {
        Assert.AreEqual(expected, ReverseWords(input));
    }

    public string ReverseWords(string input)
    {
        var result = new StringBuilder(input.Length);
        int? lastWordIndex = null;

        for (int i = input.Length - 1; i >= 0 ; i--)
        {
            if(lastWordIndex != null && !char.IsLetterOrDigit(input[i]))
            {
                result.Append(input[(i + 1)..(lastWordIndex.Value + 1)]);
                result.Append(' ');
                lastWordIndex = null;
            }

            if(lastWordIndex == null && char.IsLetterOrDigit(input[i]))
                lastWordIndex = i;
        }

        if(char.IsLetterOrDigit(input[0]))
            result.Append(input[0..(lastWordIndex.Value + 1)]);
        else
            result.Remove(result.Length - 1, 1);

        return result.ToString();
    }
}
