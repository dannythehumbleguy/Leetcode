using NUnit.Framework;

namespace Leetcode.Easy;

// DFS with recursion
public class Solution112_1 
{
    [TestCase(8, true)]
    [TestCase(38, true)]
    [TestCase(39, false)]
    public void Test1(int target, bool result)
    {
        var root = new TreeNode(3, 
            new TreeNode(1, 
                new TreeNode(4)), 
            new TreeNode(20, 
                new TreeNode(15), 
                new TreeNode(7)));
        
        Assert.AreEqual(result, HasPathSum(root, target));
    }

    public bool HasPathSum(TreeNode root, int target) => 
        root != null && RecHasPathSum(root, target, root.val); 

    private bool RecHasPathSum(TreeNode node, int target, int current)
    {
        if (target == current && node.left == null && node.right == null)
            return true;

        if (node.left != null && RecHasPathSum(node.left, target, current + node.left.val))
            return true;
        
        if (node.right != null && RecHasPathSum(node.right, target, current + node.right.val))
            return true;

        return false;
    }
}

// DFS with stack and seen nodes
public class Solution112_2
{
    [TestCase(8, true)]
    [TestCase(38, true)]
    [TestCase(39, false)]
    public void Test1(int target, bool result)
    {
        var root = new TreeNode(3, 
            new TreeNode(1, 
                new TreeNode(4)), 
            new TreeNode(20, 
                new TreeNode(15), 
                new TreeNode(7)));
        
        Assert.AreEqual(result, HasPathSum(root, target));
    }

    public bool HasPathSum(TreeNode root, int target)
    {
        if (root == null)
            return false;

        var sum = root.val;
        var stack = new Stack<TreeNode>();
        var visits = new HashSet<TreeNode>();
        stack.Push(root);

        while (stack.Count > 0)
        {
            var node = stack.Peek();
            
            var isLeaf = node.left == null && node.right == null;
            if (sum == target && isLeaf)
                return true;
            
            var childWasVisited =
                (node.left == null || visits.Contains(node.left)) &&
                (node.right == null || visits.Contains(node.right));
            if (childWasVisited)
            {
                stack.Pop();
                sum -= node.val;
            }

            if (node.left != null && !visits.Contains(node.left))
            {
                stack.Push(node.left);
                visits.Add(node.left);
                sum += node.left.val;
            }
            else if (node.right != null && !visits.Contains(node.right))
            {
                stack.Push(node.right);
                visits.Add(node.right);
                sum += node.right.val;
            }
        }

        return false;
    }
}