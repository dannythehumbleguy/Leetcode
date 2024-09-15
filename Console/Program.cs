using System.Collections.Concurrent;


var c = new ConcurrentDictionary<int, string>();
c.TryAdd(0, "hello");

Console.WriteLine(c[0]);