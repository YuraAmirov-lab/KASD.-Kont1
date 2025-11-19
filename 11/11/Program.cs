using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);

        long[] ar = Console.ReadLine().Split().Select(long.Parse).ToArray();

        long left = ar.Max();
        long right = ar.Sum();

        while (left < right)
        {
            long mid = left + (right - left) / 2;

            if (Split(ar, k, mid))
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

    static bool Split(long[] arr, int k, long maxSum)
    {
        int segm = 1;
        long currentsum = 0;

        foreach (long num in arr)
        {
            if (currentsum + num > maxSum)
            {
                segm++;
                currentsum = num;

                if (segm > k)
                {
                    return false;
                }
            }
            else
            {
                currentsum += num;
            }
        }

        return true;
    }
}