using NUnit.Framework;

namespace Leetcode.Medium;

public class Solution419_Trivial
{
    [Test]
    public void BaseTest()
    {
        var battleship = new char[][]
        {
            ['X', '.', '.', 'X'], 
            ['.', '.', '.', 'X'],
            ['X', 'X', '.', 'X']
        };
        var result = CountBattleships(battleship);
        Assert.AreEqual(3, result);
    }

    public record Point(int Y, int X);
    
    public int CountBattleships(char[][] board) 
    {
        var length = board[0].Length;
        var height = board.Length;

        bool DoesPointExist(int y, int x) => 0 <= x && x < length && 0 <= y && y < height;
        
        var rels = new Dictionary<Point, Point?>();
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < length; x++)
            {
                if(board[y][x] == '.')
                    continue;

                var newPoint = new Point(y, x);
                rels.TryAdd(newPoint, null);

                if (DoesPointExist(y - 1, x) && board[y - 1][x] == 'X')
                {
                    var relatedPoint = new Point(y - 1, x);
                    rels[relatedPoint] = newPoint;

                }
                
                if (DoesPointExist(y, x + 1) && board[y][x + 1] == 'X')
                {
                    var relatedPoint = new Point(y, x + 1);
                    rels[newPoint] = relatedPoint;
                }
            }
        }

        return rels.Count(u => u.Value == null);
    }
}


public class Solution419_Improved
{
    [Test]
    public void BaseTest()
    {
        var battleship = new char[][]
        {
            ['X', '.', '.', 'X'], 
            ['.', '.', '.', 'X'],
            ['X', 'X', '.', 'X']
        };
        var result = CountBattleships(battleship);
        Assert.AreEqual(3, result);
    }
    
    public int CountBattleships(char[][] board)
    {
        var length = board[0].Length;
        var height = board.Length;
        var count = 0;
        
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < length; x++)
            {
                if(board[y][x] == '.')
                    continue;
                
                count++;

                if (0 <= x && x < length && 0 <= y - 1 && y - 1 < height && board[y - 1][x] == 'X')
                    count--;
                
                if (0 <= x + 1 && x + 1 < length && 0 <= y && y < height && board[y][x + 1] == 'X')
                    count--;
            }
        }

        return count;
    }
}