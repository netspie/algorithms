using System.Numerics;

namespace Algorithms.Tests.Common;

public class BucketSortTests
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
    public void BucketSortTest(int[] input, int[] expected)
    {
        BucketSort(input);
        Assert.That(input.SequenceEqual(expected));
    }

    // https://www.geeksforgeeks.org/bucket-sort-2/
    public void BucketSort(int[] arr) 
    {
        var min = arr.Min();
        var max = arr.Max();

        BucketSort(arr, min, max);
    }

    // diff = 17, bc = 10, r = 2
    public void BucketSort(int[] arr, int min, int max)
    {
        if (arr.Length == 0)
            return;

        var bucketCount = 10;
        var diff = max - min;
        if (diff == 0)
            return;

        var range = (int) Math.Round(diff / (double) bucketCount);
        var buckets = new List<int>[bucketCount];
        for (int i = 0; i < bucketCount; i++)
            buckets[i] = new(range);

        for (int i = 0; i < arr.Length; i++)
        {
            var bi = ((arr[i] - min) * (bucketCount - 1)) / diff;

            buckets[bi] ??= new(range);
            buckets[bi].Add(arr[i]);
        }

        for (int bi = 0; bi < bucketCount; bi++)
        {
            var b = buckets[bi];
            if (b.Count <= 1)
                continue;

            for (int i = 0; i < b.Count - 1; i++)
                for (int j = 0; j < b.Count - i - 1; j++)
                    if (b[j] > b[j + 1])
                        (b[j], b[j + 1]) = (b[j + 1], b[j]);
        }

        for (int bi = 0, ai = 0; bi < buckets.Length; bi++)
        {
            var b = buckets[bi];
            for (int i = 0; i < b.Count; i++)
            {
                arr[ai] = b[i];
                ai++;
            }
        }
    }
}
