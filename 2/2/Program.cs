using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] input = Console.ReadLine().Split(' ');
        int[] count = new int[101];

        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(input[i]);
            count[number]++;
        }
        for (int number = 0; number <= 100; number++)
        {
            for (int j = 0; j < count[number]; j++)
            {
                Console.Write(number + " ");
            }
        }
    }
}
