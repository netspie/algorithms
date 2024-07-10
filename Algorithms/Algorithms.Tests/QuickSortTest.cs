namespace Algorithms.Tests;

public class Tests
{
    [Test]
    [TestCase(new[] { 3, 2, 1, 4 }, new[] { 1, 2, 3, 4 })]
    [TestCase(new[] { 5, 1, 12, -5, 16, 2, 12, 14 }, new[] { -5, 1, 2, 5, 12, 12, 14, 16 })]
    [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 2, 3, 4, 5 })]
    [TestCase(new[] { 3, 5, 4, 2, 6, 1 }, new[] { 1, 2, 3, 4, 5, 6 })]
    [TestCase(new[] { 5 }, new[] { 5 })]
    public void QuickSortTest(int[] input, int[] expected)
    {
        QuickSort(input);
        Assert.That(Enumerable.SequenceEqual(input, expected));
    }

    // 3, 5, 4, 2, 6, 1
    // p = 4
    // lp = 1, rp = 5

    // 3, 1, 4, 2, 6, 5
    // lp = 4, rp = 3

    // 3, 1, 4, 2, 6, 5

    public void QuickSort(int[] arr, int li = 0, int ri = int.MaxValue)
    {
        if (li > ri)
            return;

        ri = ri == int.MaxValue ? arr.Length - 1 : ri;

        var lp = li;
        var rp = ri;

        var p = arr[lp + (rp - lp) / 2];

        while (lp <= rp)
        {
            if (lp == rp)
                Console.WriteLine("");

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

    public void Sort(int[] arr, int li = 0, int ri = int.MaxValue)
    {
        if (li >= ri)
            return;

        ri = ri == int.MaxValue ? arr.Length - 1 : ri;

        var len = ri - li;
        var mi = li + len / 2;
        var p = arr[mi];

        var lp = li;
        var rp = ri;

        while (lp < rp)
        {
            while (arr[lp] <= p && lp < rp)
                lp++;

            while (arr[rp] >= p && lp < rp)
                rp--;

            (arr[lp], arr[rp]) = (arr[rp], arr[lp]);
        }

        Sort(arr, li, lp);
        Sort(arr, lp + 1, ri);
    }
}
