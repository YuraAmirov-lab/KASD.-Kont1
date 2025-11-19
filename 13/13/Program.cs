using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int n = int.Parse(input[0]);
        long k = long.Parse(input[1]);

        string firstL = Console.ReadLine();
        string[] first = firstL.Split();
        long[] a = new long[first.Length];
        for (int i = 0; i < first.Length; i++)
        {
            a[i] = long.Parse(first[i]);
        }

        string secondL = Console.ReadLine();
        string[] second = secondL.Split();
        long[] b = new long[second.Length];
        for (int i = 0; i < second.Length; i++)
        {
            b[i] = long.Parse(second[i]);
        }

        Array.Sort(a);
        Array.Sort(b);

        long left = a[0] + b[0];
        long right = a[n - 1] + b[n - 1];

        while (left < right)
        {
            long mid = left + (right - left) / 2;
            long count = 0;

            for (int i = 0; i < n; i++)
            {
                long target = mid - a[i];
                count += Count(b, target);
            }

            if (count >= k)
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }

        Console.WriteLine(left);
    }

    static long Count(long[] arr, long target)
    {
        int left = 0;
        int right = arr.Length;

        while (left < right)
        {
            int mid = (left + right) / 2;
            if (arr[mid] <= target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        return left;
    }
}