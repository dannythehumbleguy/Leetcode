using NUnit.Framework;

namespace Leetcode.Medium;

public class Solution19_1 {
    
    [TestCase(5, "2 3 4 5")]
    [TestCase(4, "1 3 4 5")]
    [TestCase(3, "1 2 4 5")]
    [TestCase(2, "1 2 3 5")]
    [TestCase(1, "1 2 3 4")]
    public void BaseTests(int n, string expected)
    {
        var head = new ListNode(1,
            new ListNode(2,
                new ListNode(3,
                    new ListNode(4,
                        new ListNode(5)))));
        
        Assert.AreEqual(expected, RemoveNthFromEnd(head, n).ToString());
    }

    [Test]
    public void CornerCase() => Assert.AreEqual(null, RemoveNthFromEnd(new ListNode(555), 1));
    
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        var current = head;
        var fake = new ListNode(-1, head);
        var beforeTargetNode = fake;

        while (current != null)
        {
            if (n > 0)
                n--;
            else
                beforeTargetNode = beforeTargetNode.next;

            current = current.next;
        }

        if (beforeTargetNode.next != null)
            beforeTargetNode.next = beforeTargetNode.next?.next;
        
        return fake.next;
    }
}