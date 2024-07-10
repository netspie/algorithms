namespace Algorithms.Code;

public class QuickSort
{
    public void Sort(int[] arr, int li = 0, int ri = int.MaxValue)
    {
        ri = ri == int.MaxValue ? arr.Length - 1 : ri;

        Partition(arr, li, ri);
    }

    void Partition(int[] arr, int li, int ri)
    {
        if (ri - li <= 1)
            return;

        var mi = (ri - li) / 2;
        var p = arr[mi];

        var lp = li;
        var rp = ri;

        while (lp < rp)
        {
            while (arr[lp] <= p)
                lp++;

            while (arr[rp] >= p)
                rp--;

            if (lp < rp)
                (arr[lp], arr[rp]) = (arr[rp], arr[lp]);
        }

        Partition(arr, li, rp);
        Partition(arr, lp, ri);
    }

    // 3, 5, 4, 2, 6, 1
    // p = 4

    // 3, 1, 4, 2, 6, 5
    // lp = 4, rp = 3

    // 3, 1, 4, 2, 6, 5
}
