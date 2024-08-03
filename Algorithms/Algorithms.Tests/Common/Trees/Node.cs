namespace Algorithms.Tests.Common.Trees;

public record Node<T>(T Value, Node<T>[]? Children = null)
{
    public override string ToString() =>
        Value?.ToString() ?? "";
}
