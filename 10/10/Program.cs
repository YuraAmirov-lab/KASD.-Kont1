using System;
using System.Collections.Generic;

public class Program
{
    static int Scores((double score, int index) a, (double score, int index) b)
    {
        if (b.score > a.score) return 1;
        if (b.score < a.score) return -1;
        return 0;
    }

    public static void Main()
    {
        string[] firstLine = Console.ReadLine().Split();
        int n = int.Parse(firstLine[0]);
        int k = int.Parse(firstLine[1]);
        double[] values = new double[n];
        double[] weights = new double[n];

        for (int i = 0; i < n; i++)
        {
            string[] data = Console.ReadLine().Split();
            values[i] = double.Parse(data[0]);
            weights[i] = double.Parse(data[1]);
        }

        double left = 0;
        double right = 10000000;
        double Rat = 0;

        for (int it = 0; it < 50; it++)
        {
            double mid = (left + right) / 2;

            List<(double score, int index)> scores = new List<(double, int)>();
            for (int i = 0; i < n; i++)
            {
                double score = values[i] - mid * weights[i];
                scores.Add((score, i));
            }

            scores.Sort(Scores);

            double totalScore = 0;
            for (int i = 0; i < k; i++)
            {
                totalScore += scores[i].score;
            }
            if (totalScore >= 0)
            {
                Rat = mid;
                left = mid;
            }
            else
            {
                right = mid;
            }
        }
        List<(double score, int index)> finalScores = new List<(double, int)>();
        for (int i = 0; i < n; i++)
        {
            double score = values[i] - Rat * weights[i];
            finalScores.Add((score, i));
        }

        finalScores.Sort(Scores);
        for (int i = 0; i < k; i++)
        {
            Console.WriteLine(finalScores[i].index + 1);
        }
    }
}