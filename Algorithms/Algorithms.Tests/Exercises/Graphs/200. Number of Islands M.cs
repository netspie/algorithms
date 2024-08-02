using System;
using System.Diagnostics;
using System.Numerics;

namespace Algorithms.Tests.Exercises.Graphs;

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
        var res = NumIslands(Grid);
        Assert.That(res == 1);
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
    const int X = 3;
    public static void Build(char[][] grid, int x, int y, HashSet<(int x, int y)> visited)
    {
        if (x.IsInRangeOf(grid) &&
            y.IsInRangeOf(grid[x]) &&
            grid[x][y] == '1' &&
            !visited.Contains((x, y)))
        {
            visited.Add((x, y));

            var dirs = new (int x, int y)[] { (x - 1, y), (x, y + 1), (x + 1, y), (x, y - 1) };
            foreach (var dir in dirs)
                if (!visited.Contains(dir))
                    Build(grid, dir.x, dir.y, visited);
        }
    }
}

public static class ArrayExtensions
{
    public static bool IsInRange<T>(this T[] arr, int i) =>
        i >= 0 && i < arr.Length;

    public static bool IsInRangeOf<T>(this int i, T[] arr) =>
        i >= 0 && i < arr.Length;
}