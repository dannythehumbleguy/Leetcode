using NUnit.Framework;

namespace Leetcode.Easy;

public class Solution111_1
{
    [Test]
    public void Test1()
    {
        var root = new TreeNode(3, 
            new TreeNode(1, 
                new TreeNode(4)), 
            new TreeNode(20, 
                new TreeNode(15), 
                new TreeNode(7)));
        
        Assert.AreEqual(3, MinDepth(root));
    }

    public int MinDepth(TreeNode root)
    {
        if (root == null)
            return 0;
        
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        var minDepth = 1;

        while (queue.Count > 0)
        {
            var levelLength = queue.Count;
            for (var i = 0; i < levelLength; i++)
            {
                var node = queue.Dequeue();
                if (node.left == null && node.right == null)
                    return minDepth;
                
                if(node.left != null)
                    queue.Enqueue(node.left);
                if(node.right != null)
                    queue.Enqueue(node.right);
            }
            minDepth++;
        }

        return minDepth;
    }
}