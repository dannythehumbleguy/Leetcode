using System.Text;

namespace Leetcode;

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }

    public override string ToString()
    {
        var sb = new StringBuilder($"{val} ");
        ToString(this, sb);
        return sb.ToString();
    }

    private void ToString(TreeNode node, StringBuilder builder)
    {
        if (node.left != null)
        {
            builder.Append($"{node.left.val} ");
            ToString(node.left, builder);
        }

        if (node.right != null)
        {
            builder.Append($"{node.right.val} ");
            ToString(node.right, builder);
        }
    }
}