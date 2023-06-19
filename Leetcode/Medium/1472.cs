using NUnit.Framework;

namespace Leetcode.Medium;

// Solution with two stacks
public class Solution1472_1
{
    [Test]
    public void BaseTest()
    {
        var bh = new BrowserHistory("leetcode.com");
        bh.Visit("google.com");
        bh.Visit("facebook.com");
        bh.Visit("youtube.com");
        Assert.AreEqual("facebook.com", bh.Back(1));
        Assert.AreEqual("google.com", bh.Back(1));
        Assert.AreEqual("facebook.com", bh.Forward(1));
        bh.Visit("linkedin.com");
        Assert.AreEqual("linkedin.com", bh.Forward(2));
        Assert.AreEqual("google.com", bh.Back(2));
        Assert.AreEqual("leetcode.com", bh.Back(7));
    }

    private class BrowserHistory
    {
        private readonly Stack<string> _actualVisits = new();
        private Stack<string> _backedVisits = new();

        public BrowserHistory(string homepage) => _actualVisits.Push(homepage);

        public void Visit(string url)
        {
            _actualVisits.Push(url);
            _backedVisits = new Stack<string>();
        }

        public string Back(int steps)
        {
            for (var i = 0; i < steps; i++)
            {
                if (_actualVisits.Count <= 1)
                    break;

                var visited = _actualVisits.Pop();
                _backedVisits.Push(visited);
            }

            return _actualVisits.Peek();
        }

        public string Forward(int steps)
        {
            if (_backedVisits.Count == 0)
                return _actualVisits.Peek();

            for (var i = 0; i < steps; i++)
            {
                var pop = _backedVisits.TryPop(out var backed);
                if (!pop)
                    break;

                _actualVisits.Push(backed);
            }

            return _actualVisits.Peek();
        }
    }
}

// Solution with linked list
public class Solution1472_2
{
    [Test]
    public void BaseTest()
    {
        var bh = new BrowserHistory("leetcode.com");
        bh.Visit("google.com");
        bh.Visit("facebook.com");
        bh.Visit("youtube.com");
        Assert.AreEqual("facebook.com", bh.Back(1));
        Assert.AreEqual("google.com", bh.Back(1));
        Assert.AreEqual("facebook.com", bh.Forward(1));
        bh.Visit("linkedin.com");
        Assert.AreEqual("linkedin.com", bh.Forward(2));
        Assert.AreEqual("google.com", bh.Back(2));
        Assert.AreEqual("leetcode.com", bh.Back(7));
    }

    private class BrowserHistory
    {
        private LinkedListNode current;

        public BrowserHistory(string homepage)
        {
            current = new LinkedListNode(null, null, homepage);
        }

        public void Visit(string url)
        {
            var node = new LinkedListNode(current, null, url);
            current.Next = node;
            current = node;
        }

        public string Back(int steps)
        {
            for (var i = 0; i < steps && current.Previous != null; i++)
                current = current.Previous;

            return current.Value;
        }

        public string Forward(int steps)
        {
            for (var i = 0; i < steps && current.Next != null; i++)
                current = current.Next;

            return current.Value;
        }

        private class LinkedListNode
        {
            public LinkedListNode Previous { get; set; }
            public LinkedListNode Next { get; set; }
            public string Value { get; set; }
            
            public LinkedListNode(LinkedListNode previous, LinkedListNode next, string value)
            {
                Previous = previous;
                Next = next;
                Value = value;
            }
        };
    }
}