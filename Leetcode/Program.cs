using System;
using System.Text;

var test1 = ("ab#c", "ab#c" ,  true);
var test2 = ("c#d#", "ab##", true);
var testCases = new[]
{
    test1, 
    test2,
};
RunTests(testCases);


void RunTests((string s1, string s2, bool result)[] cases)
{
    var c = 1;
    foreach (var testCase in cases)
    {
        var s = new Solution();
        var result = s.BackspaceCompare(testCase.s1, testCase.s2);
        Console.WriteLine(result == testCase.result
            ? $"Test {c} passed!"
            : $"Test {c} failed, result {result}.");
        c++;
    }
}

public class Solution {
    public bool BackspaceCompare(string s, string t)
    {
        return GetWithoutBackspace(s) == GetWithoutBackspace(t);
    }

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
            
            if(backSpaces > 0)
                continue;

            sb.Append(input[i]);
        }

        return sb.ToString();
    }
}