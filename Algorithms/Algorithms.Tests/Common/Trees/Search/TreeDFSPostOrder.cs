namespace Algorithms.Tests.Common.Trees.Search;

public class TreeDFSPostOrderTests
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
    public void TreeDFSInOrderTest()
    {
        var found = tree.DepthFirstSearch(10, DFSType.InOrder);
        Assert.That(found, Is.Not.Null);
    }

    [Test]
    public void TreeDFSPreOrderTest()
    {
        var found = tree.DepthFirstSearch(10, DFSType.PreOrder);
        Assert.That(found, Is.Not.Null);
    }

    [Test]
    public void TreeDFSPostOrderTest()
    {
        var found = tree.DepthFirstSearch(10, DFSType.PostOrder);
        Assert.That(found, Is.Not.Null);
    }
}

public static class TreeDFSExtensions
{
    public static Node<T>? DepthFirstSearch<T>(
        this Node<T> node, T item, DFSType type = DFSType.InOrder)
        where T : IComparable<T> =>
        type switch
        {
            DFSType.InOrder => node.DepthFirstSearch_InOrder(item),
            DFSType.PreOrder => node.DepthFirstSearch_PreOrder(item),
            DFSType.PostOrder or _ => node.DepthFirstSearch_PostOrder(item),
        };

    private static Node<T>? DepthFirstSearch_PostOrder<T>(
        this Node<T> node, T item)
        where T : IComparable<T>
    {
        if (node.Children is null)
            return node.Value.CompareTo(item) == 0 ? node : null;

        foreach (var child in node.Children)
            if (child.DepthFirstSearch_PostOrder(item) is Node<T> found)
                return found;

        if (node.Value.CompareTo(item) == 0)
            return node;

        return null;
    }

    private static Node<T>? DepthFirstSearch_PreOrder<T>(
        this Node<T> node, T item)
        where T : IComparable<T>
    {
        if (node.Value.CompareTo(item) == 0)
            return node;

        if (node.Children is null)
            return null;

        foreach (var child in node.Children)
            if (child.DepthFirstSearch_PreOrder(item) is Node<T> found)
                return found;

        return null;
    }
    
    private static Node<T>? DepthFirstSearch_InOrder<T>(
        this Node<T> node, T item)
        where T : IComparable<T>
    {
        if (node.Children is null || node.Children.Length == 0)
            return node.Value.CompareTo(item) == 0 ? node : null;

        int n = node.Children.Length;
        
        for (int i = 0; i < n; i++)
            if (i == n - 1)
            {
                if (node.Value.CompareTo(item) == 0)
                    return node;

                return node.Children[i].DepthFirstSearch_InOrder(item);
            }
            else if (node.Children[i].DepthFirstSearch_InOrder(item) is Node<T> found)
                return found;

        return null;
    }
}

public enum DFSType
{
    InOrder,
    PreOrder,
    PostOrder
}

public record Node<T>(T Value, Node<T>[]? Children = null)
{
    public override string ToString() =>
        Value?.ToString() ?? "";
}
