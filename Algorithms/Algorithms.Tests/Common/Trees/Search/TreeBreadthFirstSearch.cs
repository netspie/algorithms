namespace Algorithms.Tests.Common.Trees.Search;

public class TreeBreadthFirstSearchTests
{
    private static readonly Node<int> tree = new Node<int>(2, 
    [
        new(3, 
        [
            new(6),
            new(7)
        ]),
        new(4, 
        [
            new(9),
            new(10)
        ])
    ]);

    [Test]
    public void TreeBreadthFirstSearchTest()
    {
        var order = new List<int>(capacity: 7);
        var found = tree.BreadthFirstSearch(10, onVisit: order.Add);

        Assert.IsTrue(found is not null && found.Value == 10);
        Assert.IsTrue(Enumerable.SequenceEqual(order, [2, 3, 4, 6, 7, 9, 10]));
    }
}

public static class TreeBFSExtensions
{
    public static Node<T>? BreadthFirstSearch<T>(
        this Node<T> node, T item, Action<T>? onVisit = null) where T : IComparable<T>
    {
        var queue = new Queue<Node<T>>([node]);

        while (queue.Count > 0)
        {
            node = queue.Dequeue();
            
            onVisit?.Invoke(node.Value);
            if (node.Value.CompareTo(item) == 0)
                return node;

            if (node.Children is null)
                continue;

            foreach (var child in node.Children)
                queue.Enqueue(child);
        }

        return null;
    }
}
