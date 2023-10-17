using NUnit.Framework;

namespace Leetcode.Medium;
public class Solution_1827
{
    [Test]
    public void BaseTest()
    {
        var a = new int[][]
        {
            new int[] { 0, 5 },
            new int[] { 1, 2 },
            new int[] { 0, 2 },
            new int[] { 0, 5 },
            new int[] { 1, 3 },
        };
        var k = 5;
        var result = FindingUsersActiveMinutes(a, k);
        var expectedResult = new int[] { 0, 2, 0, 0, 0};

        Assert.IsTrue(expectedResult.SequenceEqual(result));
    }

    public static int[] FindingUsersActiveMinutes(int[][] logs, int k)
    {
        var visitedMinutes = new Dictionary<int, HashSet<int>>();

        foreach (var log in logs)
        {
            var id = log[0];
            var minute = log[1];
            var idExists = visitedMinutes.TryGetValue(id, out var minutes);
            if (!idExists)
            {
                visitedMinutes[id] = new HashSet<int>() { minute };
                continue;
            }

            var minuteExists = minutes.Contains(minute);
            if (minuteExists)
                continue;

            minutes.Add(minute);
        }

        var visitCounts = new int[k];
        foreach (var (_, minutes) in visitedMinutes)
            visitCounts[minutes.Count - 1] += 1;
        
        return visitCounts;
    }
}
