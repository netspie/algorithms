namespace Algorithms.Tests.Exercises;

public class TopKElementsInListTests
{
    [Test]
    [TestCase(new[] { 1 }, 1, new[] { 1 })]
    [TestCase(new[] { -1, -1 }, 1, new[] { -1 })]
    [TestCase(new[] { 1, 2, 2, 3, 3, 3 }, 2, new[] { 3, 2 })]
    [TestCase(new[] { 1, 1, 1, 2, 2, 3 }, 2, new[] { 1, 2 })]
    public void TopKElementsInListTest(int[] nums, int k, int[] expected)
    {
        Assert.That(TopKFrequentByBucketSort(nums, k).SequenceEqual(expected));
    }

    public int[] TopKFrequentByBucketSort(int[] nums, int k)
    {
        var count = new Dictionary<int, int>();
        var frequency = new List<int>[nums.Length + 1];

        for (int i = 0; i < nums.Length; i++)
        {
            if (!count.ContainsKey(nums[i]))
                count[nums[i]] = 1;
            else
                count[nums[i]]++;
        }

        foreach (var item in count)
        {
            frequency[item.Value] ??= new();
            frequency[item.Value].Add(item.Key);
        }

        var result = new int[k];
        for (int i = frequency.Length - 1, j = 0; i >= 0 && j < k; i--)
        {
            if (frequency[i] is null)
                continue;
            
            for (int l = 0; l < frequency[i].Count; l++, j++)
                result[j] = frequency[i][l];
        }

        return result;
    }

    public int[] TopKFrequentByHashmap(int[] nums, int k)
    {
        var map = new Dictionary<int, int>();
        var counts = new List<int>[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            if (!map.ContainsKey(num))
            {
                map[num] = 1;
                counts[1] ??= new(nums.Length);
                counts[1].Add(num);
            }
            else
            {
                var count = map[num];
                counts[count].Remove(num);

                counts[count + 1] ??= new();
                counts[count + 1].Add(num);

                map[num] = count + 1;
            }
        }

        var result = new List<int>(map.Count);
        for (int i = counts.Length - 1; i >= 0; i--)
        {
            var c = counts[i];
            if (c is not null && c.Count > 0)
                result.Add(c[0]);

            if (result.Count == k)
                break;
        }

        return result.ToArray();
    }
}
