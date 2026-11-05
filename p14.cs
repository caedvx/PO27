using System;
using System.Linq;
using System.Collections.Generic;

int[] firstLine = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
int planks = firstLine[0];
int missingPlanks = firstLine[1];

List<int> plankHeights = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

List<int> sortedHeights = new List<int>(heights);
sortedHeights.Sort();

int lowerBound = 0;
if (planks <= missingPlanks)
{
    Console.WriteLine(plankHeights.Max() * plankHeights.Count());
}
else
{
    lowerBound = sortedHeights[missingPlanks] * planks;
}
// approach this time: Pick a plank to hold the board up, then use for loops to see max area with how far I can stretch it, 
// since K <= 20 this should be doable, since we pick max 20 places to ignore the height of we get max 20 different selections to check per plank
// thus we can just check this for each plank with O(20n) complexity 