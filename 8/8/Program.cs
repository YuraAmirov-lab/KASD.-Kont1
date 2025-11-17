using System;

class Program
{
    static void Main()
    {

        double C = double.Parse(Console.ReadLine());

        double left = 0.0;
        double right = 1000000.0; 

        for (int i = 0; i < 10000; i++)
        {
            double mid = (left + right) / 2.0;
            double value = mid * mid + Math.Sqrt(mid);

            if (value < C)
            {
                left = mid;
            }
            else
            {
                right = mid;
            }
        }

        Console.WriteLine(left.ToString("F6"));
    }
}