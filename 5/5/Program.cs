using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string input = Console.ReadLine();         
        string[] parts = input.Split();              
        int[] array = new int[parts.Length];       
        for (int i = 0; i < parts.Length; i++)
        {
            array[i] = int.Parse(parts[i]);        
        }
        Array.Sort(array);
        int k = int.Parse(Console.ReadLine());
        string[] results = new string[k];

        for (int i = 0; i < k; i++)
        {
            string[] query = Console.ReadLine().Split();
            int l = int.Parse(query[0]);
            int r = int.Parse(query[1]);

            int leftIndex = LowerBound(array, l);
            int rightIndex = UpperBound(array, r);
            results[i] = (rightIndex - leftIndex).ToString();
        }

        Console.WriteLine(string.Join(" ", results));
    }

    static int LowerBound(int[] array, int value)
    {
        int left = 0;
        int right = array.Length;
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (array[mid] < value)
                left = mid + 1;
            else
                right = mid;
        }
        return left;
    }

    static int UpperBound(int[] array, int value)
    {
        int left = 0;
        int right = array.Length;
        while (left < right)
        {
            int mid = left + (right - left) / 2;
            if (array[mid] <= value)
                left = mid + 1;
            else
                right = mid;
        }
        return left;
    }
}