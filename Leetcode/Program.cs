using System;

var test1 = (new[] { 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0 }, 2 , 6);
var test2 = (new[] { 0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1 }, 3, 10);
var testCases = new[]
{
    test1, 
    test2,
};
RunTests(testCases);


void RunTests((int[] sequence, int k, int result)[] cases)
{
    var c = 1;
    foreach (var testCase in cases)
    {
        var result = LongestOnes(testCase.sequence, testCase.k);
        Console.WriteLine(result == testCase.result
            ? $"Test {c} passed!"
            : $"Test {c} failed, result {result}.");
        c++;
    }
}


int LongestOnes(int[] nums, int k)
{
    var longestSeq = 0;
    var currSeq = 0;
    var availableOnes = k;
    var availableOneIndexes = new Queue<int>(k);
    var startIdx = -1;
    
    for (var i = 0; i < nums.Length; i++)
    {
        var curr = nums[i];

        if (curr == 1)
        {
            currSeq++;
            if (startIdx == -1)
                startIdx = i;
        }
        else if (availableOnes > 0)
        {
            currSeq++;
            availableOnes--;
            availableOneIndexes.Enqueue(i);
        }
        else
        {
            var newSeq = i - startIdx;
            Console.WriteLine($"{i}:{startIdx}");
            longestSeq = newSeq > currSeq ? newSeq : currSeq;
            currSeq = newSeq;
            availableOnes++;
            startIdx = availableOneIndexes.Dequeue();
        }
    }

    return longestSeq;
}