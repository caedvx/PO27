using System;
using System.Linq;

int n = int.Parse(Console.ReadLine());
int[] a = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int b = Array.IndexOf(a, 0);
int[] c = a.Where((_, i) => i != b).ToArray();

long s = 0;
for (int k = 0; k < c.Length; k++)
    s += (long)(k + 1) * c[k];

long suffix = 0, bestSuffix = 0;
for (int k = c.Length - 1; k >= 0; k--)
{
    suffix += c[k];
    if (suffix > bestSuffix) bestSuffix = suffix;
}

Console.WriteLine(s + bestSuffix);
