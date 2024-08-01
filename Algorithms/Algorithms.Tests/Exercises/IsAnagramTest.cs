using System.Numerics;

namespace Algorithms.Tests.Exercises;

public class IsAnagramTests
{
    [Test]
    [TestCase("racecar", "carrace", true)]
    [TestCase("anagram", "nagaram", true)]
    public void IsAnagramTest(string s, string t, bool expected)
    {
        Assert.That(IsAnagram(s, t), Is.EqualTo(expected));
    }

    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
            return false;

        var sArr = s.ToCharArray();
        var tArr = t.ToCharArray();

        QuickSort(sArr);
        QuickSort(tArr);

        for (int i = 0; i < tArr.Length; i++)
            if (sArr[i] != tArr[i])
                return false;

        return true;
    }

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
