using System;

class Program
{
    static void Main()
    {
        string[] firstLine = Console.ReadLine().Split();
        double Vp = double.Parse(firstLine[0]);
        double Vf = double.Parse(firstLine[1]);
        double a = double.Parse(Console.ReadLine());
        double left = 0.0;
        double right = 1.0;
        double epsilon = 0.0000001;

        while (right - left > epsilon)
        {
            double mid = (left + right) / 2;
            double timeMid = CalculateTime(mid, Vp, Vf, a);
            double timeRight = CalculateTime(mid + epsilon, Vp, Vf, a);

            if (timeRight < timeMid)
                left = mid;
            else
                right = mid;
        }

        double result = (left + right) / 2;
        Console.WriteLine(result.ToString());
    }

    static double CalculateTime(double x, double Vp, double Vf, double a)
    {
        double distanceField = Math.Sqrt(x * x + (1 - a) * (1 - a));
        double distanceForest = Math.Sqrt((1 - x) * (1 - x) + a * a);
        return distanceField / Vp + distanceForest / Vf;
    }
}