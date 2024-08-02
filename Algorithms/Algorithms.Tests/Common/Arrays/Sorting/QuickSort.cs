using System.Diagnostics;
using System.Numerics;

namespace Algorithms.Tests.Common;

public class Tests
{
    [Test]
    [TestCase(new[] { 3, 2, 1, 4 }, new[] { 1, 2, 3, 4 })]
    [TestCase(new[] { 5, 1, 12, -5, 16, 2, 12, 14 }, new[] { -5, 1, 2, 5, 12, 12, 14, 16 })]
    [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3, 4, 5 })]
    [TestCase(new[] { 3, 5, 4, 2, 6, 1 }, new[] { 1, 2, 3, 4, 5, 6 })]
    [TestCase(new[] { 5 }, new[] { 5 })]
    [TestCase(new[] { 99, 97, 114, 114, 97, 99, 101 }, new[] { 97, 97, 99, 99, 101, 114, 114 })]
    [TestCase(new[] { 97, 110, 97, 103, 114, 97, 109 }, new[] { 97, 97, 97, 103, 109, 110, 114 })]
    [TestCase(new[] { 110, 97, 103, 97, 114, 97, 109 }, new[] { 97, 97, 97, 103, 109, 110, 114 })]
    public void QuickSortTest(int[] input, int[] expected)
    {
        QuickSort(input);
        Assert.That(input.SequenceEqual(expected));
    }

    // https://code-maze.com/csharp-quicksort-algorithm/
    public void QuickSort<T>(T[] arr, int li = 0, int ri = int.MaxValue)
        where T : INumber<T>
    {
        if (li >= ri)
            return;

        ri = ri == int.MaxValue ? arr.Length - 1 : ri;

        int lp = li;
        int rp = ri;
        T p = arr[li + (ri - li) / 2];

        while (lp <= rp)
        {
            while (arr[lp] < p)
                lp++;

            while (arr[rp] > p)
                rp--;

            if (lp <= rp)
                (arr[lp], arr[rp]) = (arr[rp--], arr[lp++]);
        }

        QuickSort(arr, li, rp);
        QuickSort(arr, lp, ri);
    }
}
