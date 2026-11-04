using System;
using System.Linq;

int n = int.Parse(Console.ReadLine());
int x = int.Parse(Console.ReadLine());
int y = int.Parse(Console.ReadLine());
int[] lengths = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Array.Sort(lengths);

long sum = 0;
int best = 0;
for (int k = 1; k <= n; k++)
{
    sum += lengths[k - 1];
    if (x * sum <= (long)y * k)
    {
        best = k;
    }
}

Console.WriteLine(best);
