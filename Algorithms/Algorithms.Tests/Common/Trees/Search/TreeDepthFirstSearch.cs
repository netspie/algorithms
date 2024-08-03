namespace Algorithms.Tests.Common.Trees.Search;

public class TreeDFSPostOrderTests
{
    private static readonly Node<int> tree = new Node<int>(2, 
    [
        new(3, 
        [
            new(6),
            new(1),
            new(7)
        ]),
        new(4, 
        [
            new(9),
            new(10)
        ])
    ]);

    [Test]
    public void TreeDFSInOrderTest()
    {
        var order = new List<int>(capacity: 7);
        var found = tree.DepthFirstSearch(10, DFSType.InOrder, onVisit: order.Add);

        Assert.IsTrue(found is not null && found.Value == 10);
        Assert.IsTrue(Enumerable.SequenceEqual(order, [6, 1, 3, 7, 2, 9, 4, 10]));
    }

    [Test]
    public void TreeDFSPreOrderTest()
    {
        var order = new List<int>(capacity: 7);
        var found = tree.DepthFirstSearch(10, DFSType.PreOrder, onVisit: order.Add);

        Assert.IsTrue(found is not null && found.Value == 10);
        Assert.IsTrue(Enumerable.SequenceEqual(order, [6, 1, 7, 3, 9, 10, 4, 2]));
    }

    [Test]
    public void TreeDFSPostOrderTest()
    {
        var order = new List<int>(capacity: 7);
        var found = tree.DepthFirstSearch(10, DFSType.PostOrder, onVisit: order.Add);

        Assert.IsTrue(found is not null && found.Value == 10);
        Assert.IsTrue(Enumerable.SequenceEqual(order, [6, 1, 7, 3, 2, 9, 10, 4]));
    }
}

public static class TreeDFSExtensions
{
    public static Node<T>? DepthFirstSearch<T>(
        this Node<T> node, T item, DFSType type = DFSType.InOrder, Action<T>? onVisit = null)
        where T : IComparable<T> =>
        type switch
        {
            DFSType.InOrder => node.DepthFirstSearch_InOrder(item, onVisit),
            DFSType.PreOrder => node.DepthFirstSearch_PreOrder(item, onVisit),
            DFSType.PostOrder or _ => node.DepthFirstSearch_PostOrder(item, onVisit),
        };

    private static Node<T>? DepthFirstSearch_PostOrder<T>(
        this Node<T> node, T item, Action<T>? onVisit = null)
        where T : IComparable<T>
    {
        if (node.Children is null)
        {
            onVisit?.Invoke(node.Value);
            return node.Value.CompareTo(item) == 0 ? node : null;
        }

        foreach (var child in node.Children)
            if (child.DepthFirstSearch_PostOrder(item, onVisit) is Node<T> found)
                return found;

        onVisit?.Invoke(node.Value);
        if (node.Value.CompareTo(item) == 0)
            return node;

        return null;
    }

    private static Node<T>? DepthFirstSearch_PreOrder<T>(
        this Node<T> node, T item, Action<T>? onVisit = null)
        where T : IComparable<T>
    {
        onVisit?.Invoke(node.Value);
        if (node.Value.CompareTo(item) == 0)
            return node;

        if (node.Children is null)
            return null;

        foreach (var child in node.Children)
            if (child.DepthFirstSearch_PreOrder(item, onVisit) is Node<T> found)
                return found;

        return null;
    }
    
    private static Node<T>? DepthFirstSearch_InOrder<T>(
        this Node<T> node, T item, Action<T>? onVisit = null)
        where T : IComparable<T>
    {
        int n = node.Children?.Length ?? 0;
        if (node.Children is not null)
            for (int i = 0; i < n - 1; i++)
            {
                if (node.Children[i].DepthFirstSearch_InOrder(item, onVisit) is Node<T> found)
                    return found;
            }

        onVisit?.Invoke(node.Value);
        if (node.Value.CompareTo(item) == 0)
            return node;

        if (node.Children is not null)
        {
            var found = node.Children[n - 1].DepthFirstSearch_InOrder(item, onVisit);
            if (found is not null)
                return found;
        }

        return null;
    }
}

public enum DFSType
{
    InOrder,
    PreOrder,
    PostOrder
}
