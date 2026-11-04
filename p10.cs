using System;
using System.Linq;

int[] cl = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

long[] duckNumber = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(long.Parse)
    .ToArray();

int[] cValues = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int colours = cl[0];
int layers = cl[1];

bool HeightWorks(int Height)
{
    long[] ducksPerColour = (long[])duckNumber.Clone();
    for (int i = 0; i < Height; i++)
    {
        long side = Height - i;
        long need = side * side;
        int c = cValues[i] - 1; 
        if (ducksPerColour[c] >= need)
        {
            ducksPerColour[c] -= need;
        }
        else return false;
    }
    return true;
}

int BinarySearch(int maxValue)
{
    int lowerBound = 0;
    int upperBound = maxValue;
    while (upperBound != lowerBound)
    {
        int guess = lowerBound + (upperBound - lowerBound + 1)/2;
        if (HeightWorks(guess))
        {
            lowerBound = guess;
        }
        else upperBound = guess - 1;
    }
    return upperBound;
}

int maxHeight = BinarySearch(layers);
Console.WriteLine(maxHeight);