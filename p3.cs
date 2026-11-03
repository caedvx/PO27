using System;
string input = Console.ReadLine();
int trulsScore = 0;
int henryScore = 0;
foreach (char c in input)
{
    if (c == 'T')
    {
        trulsScore++;
    }
    else
    {
        henryScore++;
    }
    if (((trulsScore >= henryScore + 2) && (trulsScore >= 11)) || ((henryScore >= trulsScore + 2) && (henryScore >= 11)))
    {
        trulsScore = 0;
        henryScore = 0;
    }
}
Console.WriteLine($"{trulsScore}-{henryScore}");