using NUnit.Framework;

namespace Leetcode.Medium;

public class Solution146_1 
{
    
    [Test]
    public void BaseTest()
    {
        var lRuCache = new LRUCache(2);
        lRuCache.Put(1, 1); // cache is {1=1}
        lRuCache.Put(2, 2); // cache is {1=1, 2=2}
        var res1 = lRuCache.Get(1);    // return 1
        Assert.AreEqual(1, res1);
        lRuCache.Put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
        var res2 = lRuCache.Get(2);    // returns -1 (not found)
        Assert.AreEqual(-1, res2);
        lRuCache.Put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
        var res3 = lRuCache.Get(1);    // return -1 (not found)
        Assert.AreEqual(-1, res3);
        var res4 = lRuCache.Get(3);    // return 3
        Assert.AreEqual(3, res4);
        var res5 = lRuCache.Get(4);    // return 4
        Assert.AreEqual(4, res5);
    }

    [Test]
    public void CornerCase()
    {
        var cache = new LRUCache(1);
        
        cache.Put(1, 2);
        cache.Put(2, 3);
        var res = cache.Get(2);
        Assert.AreEqual(3, res);
    }
    
    
    public class LRUCache
    {
        private readonly Dictionary<int, ListNode> _store;
        private readonly int _capacity;
        private ListNode _tail;
        private ListNode _head;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _store = new Dictionary<int, ListNode>(_capacity + 1);
        }

        private void RaiseNode(ListNode node)
        {
            // unlink node
            if (node.Next == null)  // current head  
                return;
            else if (node.Previous == null) // current tail
            {
                _tail = node.Next;
                _tail.Previous = null;
            }
            else // doesn't corner
            {
                var previous = node.Previous;
                var next = node.Next;
                previous.Next = next;
                next.Previous = previous;
            }
            
            _head.Next = node;
            node.Previous = _head;
            node.Next = null; 
            _head = node;
        }
    
        public int Get(int key)
        {
            var exist = _store.TryGetValue(key, out var node);
            if (!exist)
                return -1;

            RaiseNode(node);
            
            return node.Value;
        }
    
        public void Put(int key, int value)
        {
            var exist = _store.TryGetValue(key, out var node);
            if (exist)
            {
                RaiseNode(node);
                node.Value = value;
                return;
            }

            // Add data
            node = new ListNode(key, value);
            _store.Add(key, node);

            if (_head == null || _tail == null)
                _head = _tail = node;
            else
            {
                _head.Next = node;
                node.Previous = _head;
                _head = node;
            }
            
            if(_store.Count <= _capacity)
                return;
            // Remove old data
            var oldTail = _tail;
            _tail = oldTail.Next;
            _tail.Previous = null;

            _store.Remove(oldTail.Key);
        }
        
        public class ListNode
        {
            public int Key { get; }
            public int Value { get; set; }
            public ListNode Previous { get; set; }
            public ListNode Next { get; set; }

            public ListNode(int key, int value, ListNode previous = null)
            {
                Key = key;
                Value = value;
                Next = null;
                Previous = previous;
            }
        }
    }
}