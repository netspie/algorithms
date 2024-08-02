namespace Algorithms.Tests.Exercises.Arrays;

public class TwoSumTests
{
    [Test]
    [TestCase(new[] { 3, 4, 5, 6 }, 7, new[] { 0, 1 })]
    public void IsTwoSumTest(int[] nums, int target, int[] expected)
    {
        Assert.That(IsTwoSum(nums, target).SequenceEqual(expected));
    }

    public int[] IsTwoSum(int[] nums, int target)
    {
        var map = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            var x = nums[i];
            var diff = target - x;

            if (map.TryGetValue(diff, out int j))
                return [j, i];

            map[x] = i;
        }

        return [];
    }
}
