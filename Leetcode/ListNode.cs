using System.Text;

namespace Leetcode;

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        var current = this;
        while (current != null)
        {
            sb.Append(current.val + " ");
            current = current.next;
        }

        return sb.ToString().Trim();
    }
}