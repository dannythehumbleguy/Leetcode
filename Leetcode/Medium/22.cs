using NUnit.Framework;

namespace Leetcode.Medium;

// Recursion
public class Solution22_1
{
    [Test]
    public void TestCase1()
    {
        var res = GenerateParenthesis(3);
        var expected = new List<string>
            { "((()))", "(()())", "(())()", "()(())", "()()()" };

        var allParenthesisExist = expected.All(u => res.Any(v => v == u));
        Assert.IsTrue(allParenthesisExist);
    }
    
    [Test]
    public void TestCase2()
    {
        var res = GenerateParenthesis(1);
        var expected = new List<string>
            { "()" };

        var allParenthesisExist = expected.All(u => res.Any(v => v == u));
        Assert.IsTrue(allParenthesisExist);
    }

    public IList<string> GenerateParenthesis(int n)
    {
        var current = new char[2 * n];
        var res = new List<string>();
        GenerateParenthesisRec(n, n, n, current, res);

        return res;
    }

    private void GenerateParenthesisRec(int n, int r, int l, char[] current, List<string> result)
    {
        if (r == 0 && l == 0)
        {
            result.Add(new string(current));
            return;
        }

        if (l > 0)
        {
            var idx = 2 * n - l - r;
            current[idx] = '(';
            GenerateParenthesisRec(n, r, l - 1, current, result);
            current[idx] = default;
        }

        if (r > 0 && l < r)
        {
            var idx = 2 * n - l - r;
            current[idx] = ')';
            GenerateParenthesisRec(n, r - 1, l, current, result);
            current[idx] = default;
        }
    }
}