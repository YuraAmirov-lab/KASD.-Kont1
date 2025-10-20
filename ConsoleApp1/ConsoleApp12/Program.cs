using System;

class Program
{
    static void SiftDown(int[] arr, int i, int n)
    {
        int largest = i;      
        int left = 2 * i + 1;  
        int right = 2 * i + 2; 

        if (left < n && arr[left] > arr[largest])
            largest = left;

        if (right < n && arr[right] > arr[largest])
            largest = right;

        if (largest != i)
        {
            int temp = arr[i];
            arr[i] = arr[largest];
            arr[largest] = temp;
            SiftDown(arr, largest, n);
        }
    }
    static void HeapSort(int[] arr)
    {
        int n = arr.Length;

        for (int i = n / 2 - 1; i >= 0; i--)
            SiftDown(arr, i, n);

        for (int i = n - 1; i > 0; i--)
        {
            int temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;
            SiftDown(arr, 0, i);
        }
    }

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] input = Console.ReadLine().Split(' ');
        int[] arr = new int[n];

        for (int i = 0; i < n; i++)
            arr[i] = int.Parse(input[i]);
        HeapSort(arr);
        Console.WriteLine(string.Join(" ", arr));
    }
}
