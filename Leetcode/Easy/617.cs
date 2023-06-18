using NUnit.Framework;

namespace Leetcode.Easy;

// Solution with DFS and recursion
public class Solution617_1
{
    [Test]
    public void BaseTest()
    {
        var root1 = new TreeNode(1,
            new TreeNode(3,
                new TreeNode(5)),
            new TreeNode(2));

        var root2 = new TreeNode(2,
            new TreeNode(1,
                null,
                new TreeNode(4)),
            new TreeNode(3,
                null,
                new TreeNode(7)));

        Assert.AreEqual("3 4 5 4 5 7 ", MergeTrees(root1, root2).ToString());
    }

    public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
    {
        if (root1 == null)
            return root2;
        if (root2 == null)
            return root1;

        var result = new TreeNode(root1.val + root2.val);

        MergeTreesRec(root1, root2, result);

        return result;
    }

    private void MergeTreesRec(TreeNode root1, TreeNode root2, TreeNode result)
    {
        if (root1.left != null && root2.left != null)
        {
            result.left = new TreeNode(root1.left.val + root2.left.val);
            MergeTreesRec(root1.left, root2.left, result.left);
        }
        else if (root1.left != null && root2.left == null)
            result.left = root1.left;
        else if (root1.left == null && root2.left != null)
            result.left = root2.left;

        if (root1.right != null && root2.right != null)
        {
            result.right = new TreeNode(root1.right.val + root2.right.val);
            MergeTreesRec(root1.right, root2.right, result.right);
        }
        else if (root1.right != null && root2.right == null)
            result.right = root1.right;
        else if (root1.right == null && root2.right != null)
            result.right = root2.right;
    }
}

// Solution with BFS and queue
public class Solution617_2
{
    [Test]
    public void BaseTest()
    {
        var root1 = new TreeNode(1,
            new TreeNode(3,
                new TreeNode(5)),
            new TreeNode(2));

        var root2 = new TreeNode(2,
            new TreeNode(1,
                null,
                new TreeNode(4)),
            new TreeNode(3,
                null,
                new TreeNode(7)));

        Assert.AreEqual("3 4 5 4 5 7 ", MergeTrees(root1, root2).ToString());
    }

    public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
    {
        if (root1 == null)
            return root2;
        if (root2 == null)
            return root1;

        var queue = new Queue<(TreeNode Node1, TreeNode Node2, bool isLeft, TreeNode resultNode)>();
        var result = new TreeNode(root1.val + root2.val);
        if (root1.left != null || root2.left != null)
            queue.Enqueue((root1.left, root2.left, true, result));
        if (root1.right != null || root2.right != null)
            queue.Enqueue((root1.right, root2.right, false, result));

        while (queue.Count > 0)
        {
            var levelLength = queue.Count;
            for (var i = 0; i < levelLength; i++)
            {
                var (node1, node2, isLeft, resultNode) = queue.Dequeue();

                TreeNode treeNodeForResultNode = null;
                if (node1 != null && node2 != null)
                {
                    treeNodeForResultNode = new TreeNode(node1.val + node2.val);
                    if (node1.right != null || node2.right != null)
                        queue.Enqueue((node1.right, node2.right, false, treeNodeForResultNode));
                    if (node1.left != null || node2.left != null)
                        queue.Enqueue((node1.left, node2.left, true, treeNodeForResultNode));
                }
                else if (node1 != null)
                    treeNodeForResultNode = node1;
                else if (node2 != null)
                    treeNodeForResultNode = node2;

                if (isLeft)
                    resultNode.left = treeNodeForResultNode;
                else
                    resultNode.right = treeNodeForResultNode;
            }
        }

        return result;
    }
}