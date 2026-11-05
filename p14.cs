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

int heightLowerBound = 0;
if (planks <= missingPlanks)
{
    Console.WriteLine(plankHeights.Max() * plankHeights.Count());
    return;
}
else
{
    heightLowerBound = sortedHeights[missingPlanks];
}
// approach this time: Pick a plank to hold the board up, then use for loops to see max area with how far I can stretch it, 
// since K <= 20 this should be doable, since we pick max 20 places to ignore the height of we get max 20 different selections to check per plank
// thus we can just check this for each plank with O(20n) complexity 
long maxArea = 0;
for (int plank = 0; plank < planks; plank++) 
{
    int afterShortPlanks = 0;
    int beforeShortPlanks = 0;
    int firstShortPlank = 0;
    int lastShortPlank = 0;
    int[] shortPlanks = new int[40];
    for (int i = plank + 1; afterShortPlanks < 20 && i < planks; i++)
    {
        if (plankHeights[i] < plankHeights[plank])
        {
            shortPlanks[20 + afterShortPlanks] = i;
            afterShortPlanks++;
        } 
        
    }
    for (int i = plank; beforeShortPlanks < 20 && i >= 0; i++)
    {
        if (plankHeights[i] < plankHeights[plank])
        {
            shortPlanks[0 + beforeShortPlanks] = i;
            beforeShortPlanks++;
        }
    }
    int maxWidth = 0;
    for (int i = 0; i < 40; i++)
    {
        maxWidth = Math.Max(maxWidth, shortPlanks[i +  20] - shortPlanks[i]);
    }
    maxArea = Math.Max(maxArea, maxWidth * plankHeights[plank]); 
}
Console.WriteLine(maxArea);