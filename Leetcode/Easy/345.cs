using NUnit.Framework;

namespace Leetcode.Easy;

public class Solution_345
{
    private readonly char[] Vowels = new[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

    [TestCase("hello", "holle")]
    [TestCase("leetcode", "leotcede")]
    [TestCase(" ", " ")]
    public void BaseTest(string input, string expectedResult)
    {
        var result = ReverseVowels(input);
        Assert.AreEqual(expectedResult, result);
    }

    public string ReverseVowels(string input)
    {
        var left = 0;
        var right = input.Length - 1;
        var result = new char[input.Length];

        while (left <= right)
        {
            var leftValue = input[left];
            var rightValue = input[right];
            var isLeftVowel = Vowels.Contains(leftValue);
            var isRightVowel = Vowels.Contains(rightValue);

            if(isLeftVowel && isRightVowel)
            {
                result[left] = rightValue;
                result[right] = leftValue;
                left++;
                right--;
                continue;
            }

            if(!isLeftVowel)
            {
                result[left] = leftValue;
                left++;
            }

            if(!isRightVowel) 
            {
                result[right] = rightValue;
                right--;
            }
        }

        return new string(result);
    }
}