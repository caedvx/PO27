using System;
using System.Linq;
using System.Collections.Generic;

int[] firstLine = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
int planks = firstLine[0];
int missingPlanks = firstLine[1];
List<int> heights = new List<int>();
for (int i = 0; i < planks; i++)
{
    heights.Add(int.Parse(Console.ReadLine()));
}
List<int> sortedHeights = new List<int>(heights);
sortedHeights.Sort();
int minHeight;
int answer;

if (missingPlanks < planks)
{
    minHeight = sortedHeights[missingPlanks];
}
else
{ 
    answer = heights.Max() * planks;
}

int maxHeight = sortedHeights.Max();

int maxArea = 0;



int MaxPlanksOverHeight(int height, int allowedSkips)
{
    int maxValueSoFar;
    int head = 0;
    int tail = 0;
    int skips = 0;
    int fails = 0;
    int[] skipIndex = new int[heights.Count];
    bool hasIndexOverHeight = false;
    for (int i = 0; i < heights.Count; i++)
    {
        head = i;
        if (heights[i] < height)
        {
            skipIndex[skips] = i;
            skips++;
        }
        else if (heights[i] >= height)
        {
            hasIndexOverHeight = true;
        }
        if (skips <= allowedSkips)
        {
            if (hasIndexOverHeight)
            {
            maxValueSoFar = Math.Max(maxValueSoFar, head - tail + 1);
            }
        }
        else
        {
            hasIndexOverHeight = false;
            skips = 0;
            fails++;
            tail = skipIndex[fails - 1];
        }
    }
}