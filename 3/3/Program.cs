using System;

class Program
{
    static long Merge(int[] arr, int left, int mid, int right, int[] temp)
    {
        int i = left;    
        int j = mid + 1;  
        int k = left;    
        long inversions = 0;

        while (i <= mid && j <= right)
        {
            if (arr[i] <= arr[j])
            {
                temp[k++] = arr[i++];
            }
            else
            {
                temp[k++] = arr[j++];
                inversions += (mid - i + 1); 
            }
        }
        while (i <= mid)
            temp[k++] = arr[i++];

        while (j <= right)
            temp[k++] = arr[j++];

        for (i = left; i <= right; i++)
            arr[i] = temp[i];

        return inversions;
    }

    static long MergeSort(int[] arr, int left, int right, int[] temp)
    {
        long inversions = 0;

        if (left < right)
        {
            int mid = (left + right) / 2;

            inversions += MergeSort(arr, left, mid, temp);
            inversions += MergeSort(arr, mid + 1, right, temp);
            inversions += Merge(arr, left, mid, right, temp);
        }

        return inversions;
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] input = Console.ReadLine().Split(' ');
        int[] arr = new int[n];

        for (int i = 0; i < n; i++)
            arr[i] = int.Parse(input[i]);

        int[] temp = new int[n];

        long result = MergeSort(arr, 0, n - 1, temp);
        Console.WriteLine(result);
    }
}