using System.Numerics;

namespace Algorithms.Tests.Exercises;

public class NumberOfIslandsTests
{
    public static readonly char[][] Grid = {
        new[] { '1','1','1','1','0' },
        new[] { '1','1','0','1','0' },
        new[] { '1', '1', '0', '0', '0' },
        new[] { '0', '0', '0', '0', '0' } };
    
    [Test]
    public void NumberOfIslandsTest()
    {
        Assert.That(NumIslands(Grid) == 1);
    }

    public static int NumIslands(char[][] grid)
    {
        var visited = new HashSet<(int x, int y)>();

        int count = 0;
        for (int x = 0; x < grid.Length; x++)
            for (int y = 0; y < grid[x].Length; y++)
            {
                if (grid[x][y] == '0' || visited.Contains((x, y)))
                    continue;

                Build(grid, x, y, visited);
                count++;
            }

        return count;
    }

    public record Node((int x, int y) Value, List<Node>? Children = null);

    public static Node? Build(char[][] grid, int x, int y, HashSet<(int x, int y)> visited)
    {
        if (x >= 0 && x < grid.Length && y >= 0 && y < grid[x].Length && grid[x][y] == '1')
        {
            visited.Add((x, y));

            var children = new List<Node>(capacity: 4);
            if (!visited.Contains((x - 1, y)) && Build(grid, x - 1, y, visited) is Node nodeLeft)
                children.Add(nodeLeft);

            if (!visited.Contains((x, y + 1)) && Build(grid, x, y + 1, visited) is Node nodeBottom)
                children.Add(nodeBottom);

            if (!visited.Contains((x + 1, y)) && Build(grid, x + 1, y, visited) is Node nodeRight)
                children.Add(nodeRight);

            if (!visited.Contains((x, y - 1)) && Build(grid, x, y - 1, visited) is Node nodeTop)
                children.Add(nodeTop);

            return new Node((x, y), children);
        }

        return null;
    }
}
