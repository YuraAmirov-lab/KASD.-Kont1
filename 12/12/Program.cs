using System;

class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        long n = long.Parse(input[0]);
        long k = long.Parse(input[1]);

        long left = 1;
        long right = n * n;

        while (left < right)
        {
            long mid = left + (right - left) / 2;
            long count = 0;

            for (long i = 1; i <= n; i++)
            {
                count += Math.Min(n, mid / i);
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
}