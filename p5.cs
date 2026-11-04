using System;
using System.Collections.Generic;

int friends = int.Parse(Console.ReadLine());
var best = new Dictionary<string, (string name, int rating)>();

for (int i = 0; i < friends; i++)
{
    string[] elements = Console.ReadLine().Split(' ');
    string name = elements[0];
    int rating = int.Parse(elements[1]);
    string date = elements[2];

    if (!best.ContainsKey(date) || rating > best[date].rating)
    {
        best[date] = (name, rating);
    }
}

var namesToPrint = new List<string>();
foreach (var entry in best.Values)
{
    namesToPrint.Add(entry.name);
}
namesToPrint.Sort(StringComparer.Ordinal);

Console.WriteLine(namesToPrint.Count);
foreach (string name in namesToPrint)
{
    Console.WriteLine(name);
}
