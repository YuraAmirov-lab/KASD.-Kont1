using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] firstLine = Console.ReadLine().Split();
        int n = int.Parse(firstLine[0]);
        int k = int.Parse(firstLine[1]);
        string firstArrayInput = Console.ReadLine();
        string[] firstArrayParts = firstArrayInput.Split();
        int[] arr = new int[firstArrayParts.Length];
        for (int i = 0; i < firstArrayParts.Length; i++)
        {
            arr[i] = int.Parse(firstArrayParts[i]);
        }
        string secondArrayInput = Console.ReadLine();
        string[] secondArrayParts = secondArrayInput.Split();
        int[] q = new int[secondArrayParts.Length];
        for (int i = 0; i < secondArrayParts.Length; i++)
        {
            q[i] = int.Parse(secondArrayParts[i]);
        }

        foreach (int x in q)
        {
            int low = 0;
            int high = n - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (arr[mid] < x)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            int answer;
            if (low == 0)
            {
                answer = arr[0];
            }
            else if (low == n)
            {
                answer = arr[n - 1];
            }
            else
            {
                long diff1 = Math.Abs((long)arr[low - 1] - x);
                long diff2 = Math.Abs((long)arr[low] - x);

                if (diff1 < diff2)
                {
                    answer = arr[low - 1];
                }
                else if (diff1 > diff2)
                {
                    answer = arr[low];
                }
                else
                {
                    answer = arr[low - 1];
                }
            }

            Console.WriteLine(answer);
        }
    }
}