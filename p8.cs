using System;
using System.Linq;
int people = int.Parse(Console.ReadLine());
int[] birthYear = new int[people];
int[] deathYear = new int[people];
int[] orderOfBirths = new int[people];
int[] speeches = new int[people];
for (int i = 0; i < people; i++)
{
    int[] input = Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();
    birthYear[i] = input[0];
    deathYear[i] = input[1];
    orderOfBirths[i] = i;
}
int[] keys = (int[])birthYear.Clone();
Array.Sort(keys, orderOfBirths);
int startYear = birthYear[orderOfBirths[0]];
for (int i = 0; i < people; i++)
{
    int personNr = orderOfBirths[i];
    speeches[personNr] = Math.Max(0, deathYear[personNr] - Math.Max(birthYear[personNr], startYear));
    startYear = Math.Max(deathYear[personNr], startYear);
}  
Console.WriteLine(string.Join(Environment.NewLine, speeches));
