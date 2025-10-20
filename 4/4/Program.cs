using System;
using System.Collections.Generic;

class Program
{
    static List<int> heap = new List<int>();

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();

            if (line[0] == '0')
            {
                string[] parts = line.Split(' ');
                int number = int.Parse(parts[1]);
                AddNumber(number);
            }
            else
            {
                int max = GetMax();
                Console.WriteLine(max);
            }
        }
    }
    static void AddNumber(int number)
    {
        heap.Add(number);

        int index = heap.Count - 1;
        while (index > 0)
        {
            int parentIdx = (index - 1) / 2;

            if (heap[index] > heap[parentIdx])
            {
                int temp = heap[index];
                heap[index] = heap[parentIdx];
                heap[parentIdx] = temp;

                index = parentIdx;
            }
            else
            {
                break;
            }
        }
    }
    static int GetMax()
    {
        int max = heap[0];

        heap[0] = heap[heap.Count - 1];
        heap.RemoveAt(heap.Count - 1);
        int index = 0;
        while (true)
        {
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;
            int largest = index;

            if (leftChild < heap.Count && heap[leftChild] > heap[largest])
                largest = leftChild;

            if (rightChild < heap.Count && heap[rightChild] > heap[largest])
                largest = rightChild;

            if (largest != index)
            {
                int temp = heap[index];
                heap[index] = heap[largest];
                heap[largest] = temp;

                index = largest;
            }
            else
            {
                break;
            }
        }
        return max;
    }
}